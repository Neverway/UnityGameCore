//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_NetServer : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;
    [SerializeField] private TMP_InputField targetAddressField;
    [SerializeField] private TMP_InputField targetPortField;
    [SerializeField] private TMP_InputField playerNameField;
    [SerializeField] private UI_Menu errorMessageMenu;
    private System_SceneLoader sceneLoader;
    private UnityTransport transport;
    private Net_ClientData clientData;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    startHostButton.onClick.AddListener(() =>
	    {
		    NetworkManager.Singleton.StartHost();
		    gameObject.GetComponent<UI_Menu>().CloseMenu();
		    NetworkManager.Singleton.SceneManager.LoadScene("mp_lobby", LoadSceneMode.Single);
	    });
	    startClientButton.onClick.AddListener(() =>
	    {
		    NetworkManager.Singleton.StartClient();
		    //NetworkManager.Singleton.SceneManager.LoadScene("mp_lobby", LoadSceneMode.Single);
		    gameObject.GetComponent<UI_Menu>().CloseMenu();
	    });

	    transport = FindObjectOfType<UnityTransport>();
	    clientData = FindObjectOfType<Net_ClientData>();
	    clientData.netCharacter = 0; // reset this value when re-loading the scene (since the dropdown resets as well)
    }

    private void Update()
    {
	    if (targetAddressField.text == "") transport.ConnectionData.Address = "127.0.0.1";
	    if (targetPortField.text == "") transport.ConnectionData.Port =  ushort.Parse("25566");
	    if (playerNameField.text == "") clientData.netUsername = "NetPlayer";
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void UpdatedAddressField()
    {
	    if (!transport) return;
	    transport.ConnectionData.Address = targetAddressField.text;
    }
    public void UpdatedPortField()
    {
	    if (!transport) return;
	    transport.ConnectionData.Port = ushort.Parse(targetPortField.text);
    }
    public void UpdatedNameField()
    {
	    clientData.netUsername = playerNameField.text;
    }
    public void UpdatedCharacterField(int _value)
    {
	    clientData.netCharacter = _value;
    }
}

