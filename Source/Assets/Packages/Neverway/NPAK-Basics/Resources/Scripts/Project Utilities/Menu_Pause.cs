//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: Provide functions for the buttons on the pause screen for this
//  project
// Applied to: The root of the pause menu UI
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(UI_Menu))]
public class Menu_Pause : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool menuIsOpen;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private UI_Menu menu;
    private Input_Actions.Player2DActions action;
    private System_SceneLoader sceneLoader;
    private System_MenuManager menuManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    public void Awake()
    {
	    menu = GetComponent<UI_Menu>();
	    action = new Input_Actions().Player2D;
	    action.Enable();
    }

    private void Update()
    {
	    if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
	    if (!menuManager) return;
	    if (action.Start.WasPressedThisFrame())
	    {
		    if (!menuIsOpen && !menuManager.menuOpen) menu.OpenMenu();
		    if (menuIsOpen) menu.CloseMenu();
		    menuIsOpen = !menuIsOpen;
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void CloseMenu()
    {
	    menu.CloseMenu();
	    menuIsOpen = false;
    }
    public void QuitToTitle(string _targetScene)
    {
	    if (!sceneLoader) sceneLoader = FindObjectOfType<System_SceneLoader>();
	    NetworkManager.Singleton.Shutdown();
		if (sceneLoader) sceneLoader.LoadScene(_targetScene);
    }
}

