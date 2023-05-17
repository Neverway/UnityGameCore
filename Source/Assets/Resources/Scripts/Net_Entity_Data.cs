//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Assign things like the player name and character
// Applied to: The root of a netPlayer
//
//=============================================================================

using TMPro;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class Net_Entity_Data : NetworkBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool characterInitialized;
    private float randomInt;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Net_ClientData clientData;
    private Animator entityAnimator;
    private Entity entity;
    private NetworkObject networkObject;
    [SerializeField] private TMP_Text nameTag;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    clientData = FindObjectOfType<Net_ClientData>();
	    entityAnimator = GetComponent<Animator>();
	    entity = GetComponent<Entity>();
	    networkObject = GetComponent<NetworkObject>();
    }

    private void Update()
    {
	    UpdateNameServerRPC(NetworkManager.Singleton.LocalClientId, clientData.netUsername);
	    UpdateCharacterServerRPC(NetworkManager.Singleton.LocalClientId, clientData.netCharacter);
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    [ServerRpc(RequireOwnership = false)]
    private void UpdateNameServerRPC(ulong _localID, string _username)
    {
	    UpdateNameClientRPC(_localID, _username);
    }
    [ClientRpc]
    private void UpdateNameClientRPC(ulong _localID, string _username)
    {
	    // If this is not the local player, exit
	    if (_localID != networkObject.OwnerClientId) return;
	    if (_username.Length > 16) return;
	    nameTag.text = _username;
    }

    [ServerRpc(RequireOwnership = false)]
    private void UpdateCharacterServerRPC(ulong _localID, int _character)
    {
	    UpdateCharacterClientRPC(_localID, _character);
    }
    [ClientRpc]
    private void UpdateCharacterClientRPC(ulong _localID, int _character)
    {
	    // If this is not the local player, exit
	    if (_localID != networkObject.OwnerClientId) return;
	    entityAnimator.runtimeAnimatorController = clientData.characters[_character].characterAnimator;
	    entity.stats = clientData.characters[_character].characterStats;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    [ServerRpc(RequireOwnership = false)]
    public void InteractServerRPC(ulong _localID, float _rotation)
    {
	    InteractClientRPC(_localID, _rotation);
    }
    [ClientRpc]
    private void InteractClientRPC(ulong _localID, float _rotation)
    {
	    // If this is not the local player, exit
	    if (_localID != networkObject.OwnerClientId) return;
	    Instantiate(entity.interactPrefab, transform.position, Quaternion.Euler(0, 0, _rotation));
    }
}

