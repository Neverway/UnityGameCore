//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class Net_Lobby : MonoBehaviour
{
	//=-----------------=
	// Public Variables
	//=-----------------=
	public ServerSettings serverSettings;
	// Selection parameters
	public string selectedLobbyID;
	public string selectedLobbyCode;
	public string filterMode = "Newest";
	public string filterGameMode = "Normal";


	//=-----------------=
	// Private Variables
	//=-----------------=
	private Lobby hostLobby;
	private Lobby joinedLobby;
	// Server heartbeat stuff
	private float heartbeatTimer;
	private float lobbyUpdateTimer;
	private QueryLobbiesOptions queryLobbiesOptions;


	//=-----------------=
	// Reference Variables
	//=-----------------=


	//=-----------------=
	// Mono Functions
	//=-----------------=
	private async void Start()
	{
		await UnityServices.InitializeAsync(); // Async and await are used to keep game running while waiting for network response

		AuthenticationService.Instance.SignedIn += () =>
		{
			Debug.Log("Network: Signed in as " + AuthenticationService.Instance.PlayerId);
		};

		await AuthenticationService.Instance.SignInAnonymouslyAsync(); // This can be replaced with service specific accounts

	}

	private void Update()
	{
		HandleLobbyHeartbeat();
		HandleLobbyPollUpdates();
	}

	//=-----------------=
	// Internal Functions
	//=-----------------=
	// Keep a hosted server from becoming inactive (inactive servers are not join-able)
	private async void HandleLobbyHeartbeat()
	{
		if (hostLobby == null) return;
		heartbeatTimer -= Time.deltaTime;
		if (!(heartbeatTimer < 0f)) return;
		float heartbeatTimerMax = 15;
		heartbeatTimer = heartbeatTimerMax;
		await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
	}
	
	// Keep joined server settings synced with host
	private async void HandleLobbyPollUpdates()
	{
		if (joinedLobby == null) return;
		lobbyUpdateTimer -= Time.deltaTime;
		if (!(lobbyUpdateTimer < 0f)) return;
		float lobbyUpdateTimerMax = 1.1f;
		lobbyUpdateTimer = lobbyUpdateTimerMax;
		Lobby lobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);
		joinedLobby = lobby;
	}
	
	[Serializable]
	public class ServerSettings
	{
		public string lobbyName = "New server";
		public int maxPlayers = 4;
		public bool privateServer;
		public string gameMode = "Normal";
	}
	
	private void SetFilterMode(string _filterMode)
	{
		switch (_filterMode)
		{
			case "Newest":
				queryLobbiesOptions = new QueryLobbiesOptions
				{
					Count = 100,
					Filters = new List<QueryFilter> { new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT) },
					Order = new List<QueryOrder> { new QueryOrder(false, QueryOrder.FieldOptions.Created) }
				};
				break;
			case "Name":
				queryLobbiesOptions = new QueryLobbiesOptions
				{
					Count = 100,
					Filters = new List<QueryFilter> { new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT) },
					Order = new List<QueryOrder> { new QueryOrder(false, QueryOrder.FieldOptions.Name) }
				};
				break;
			case "Players":
				queryLobbiesOptions = new QueryLobbiesOptions
				{
					Count = 100,
					Filters = new List<QueryFilter> { new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT) },
					Order = new List<QueryOrder> { new QueryOrder(false, QueryOrder.FieldOptions.AvailableSlots) }
				};
				break;
			case "GameMode":
				queryLobbiesOptions = new QueryLobbiesOptions
				{
					Count = 100,
					Filters = new List<QueryFilter>
					{
						new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT),
						new QueryFilter(QueryFilter.FieldOptions.S1, filterGameMode, QueryFilter.OpOptions.EQ)
					},
					Order = new List<QueryOrder> { new QueryOrder(false, QueryOrder.FieldOptions.AvailableSlots) }
				};
				break;
		}
	}

	private Player GetPlayer()
	{
		return new Player
		{
			Data = new Dictionary<string, PlayerDataObject>
			{
				{ "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, "Player " + AuthenticationService.Instance.PlayerId.Substring(4)) }
			}
		};
	}


	//=-----------------=
    // External Functions
    //=-----------------=
    private async void CreateLobby()
    {
	    try
	    {
		    CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
		    {
			    IsPrivate =  serverSettings.privateServer,
			    Player = GetPlayer(),
			    Data = new Dictionary<string, DataObject>
			    {
				    {"GameMode", new DataObject(DataObject.VisibilityOptions.Public, serverSettings.gameMode, DataObject.IndexOptions.S1)}
			    }
		    };
		    Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(serverSettings.lobbyName, serverSettings.maxPlayers, createLobbyOptions);
		    hostLobby = lobby;
		    joinedLobby = hostLobby;
		    Debug.Log("Network: Created lobby Name[" + lobby.Name + "] Players[" + lobby.MaxPlayers + "] ID[" + lobby.Id + "] Code[" + lobby.LobbyCode + "]");
		    PrintPlayers(hostLobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void ListLobbies()
    {
	    try
	    {
		    SetFilterMode(filterMode);
		    QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);
		    
		    Debug.Log("Network: Lobbies found " + queryResponse.Results.Count);
		    foreach (Lobby lobby in queryResponse.Results)
		    {
			    Debug.Log("Network: Name[" + lobby.Name + "] MaxPlayers[" + lobby.MaxPlayers + "] GameMode[" + lobby.Data["GameMode"].Value + "]");
		    }
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void JoinLobbyBySelectedID()
    {
	    if (selectedLobbyID == "") return;
	    try
	    {
		    JoinLobbyByIdOptions joinLobbyByIDOptions = new JoinLobbyByIdOptions { Player = GetPlayer() };
		    Lobby lobby = await Lobbies.Instance.JoinLobbyByIdAsync(selectedLobbyID, joinLobbyByIDOptions);
		    joinedLobby = lobby;
		    PrintPlayers(lobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void JoinLobbyBySelectedCode()
    {
	    try
	    {
		    JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions { Player = GetPlayer() };
		    Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(selectedLobbyCode, joinLobbyByCodeOptions);
		    joinedLobby = lobby;
		    PrintPlayers(lobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void QuickJoinLobby()
    {
	    try
	    {
		    QuickJoinLobbyOptions quickJoinLobbyOptions = new QuickJoinLobbyOptions { Player = GetPlayer() };
		    Lobby lobby = await Lobbies.Instance.QuickJoinLobbyAsync(quickJoinLobbyOptions);
		    joinedLobby = lobby;
		    PrintPlayers(lobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private void PrintPlayers()
    {
	    PrintPlayers(joinedLobby);
    }

    private void PrintPlayers(Lobby lobby)
    {
	    Debug.Log("Network: Listing current players on " + lobby.Name + " (GameMode[" + lobby.Data["GameMode"].Value+"])");
	    foreach (Player player in lobby.Players) { Debug.Log(player.Data["PlayerName"].Value); }
    }

    private async void ServerLeaveLobby()
    {
	    try { await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId); }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void ServerKickPlayer(string _playerID)
    {
	    try { await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, _playerID); }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void ServerSetHost(string _playerID)
    {
	    try
	    {
		    hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
		    {
			    HostId = _playerID
		    });
		    joinedLobby = hostLobby;
		    PrintPlayers(hostLobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void ServerQuit(string _playerID)
    {
	    try { await LobbyService.Instance.DeleteLobbyAsync(joinedLobby.Id); }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }

    private async void ServerSetGameMode(string _gameMode)
    {
	    try
	    {
		    hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
		    {
			    Data = new Dictionary<string, DataObject>
			    {
				    {"GameMode", new DataObject(DataObject.VisibilityOptions.Public, _gameMode)}
			    }
		    });
		    joinedLobby = hostLobby;
		    PrintPlayers(hostLobby);
	    }
	    catch (LobbyServiceException exception) { Debug.Log("Network: " + exception); }
    }
}

