//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class Menu_Pause : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private UnityEvent OnMenuOpen;
    [SerializeField] private UnityEvent OnMenuClose;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool active;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_SceneLoader sceneLoader;
    private System_MenuManager menuManager;
    private Input_Actions.Player2DActions action;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    public void Awake()
    {
	    sceneLoader = FindObjectOfType<System_SceneLoader>();
	    menuManager = FindObjectOfType<System_MenuManager>();
	    action = new Input_Actions().Player2D;
	    action.Enable();
    }

    private void Update()
    {
	    if (!action.Start.WasPressedThisFrame()) return;
	    switch (menuManager.menuOpen)
	    {
		    case false:
			    OnMenuOpen.Invoke();
			    menuManager.menuOpen = true;
			    break;
		    case true when active:
			    ClosePauseMenu();
			    break;
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void ClosePauseMenu()
    {
	    OnMenuClose.Invoke();
	    menuManager.menuOpen = false;
    }
    public void QuitToTitle(string _targetScene)
    {
	    ClosePauseMenu();
	    if (!sceneLoader) sceneLoader = FindObjectOfType<System_SceneLoader>();
	    NetworkManager.Singleton.Shutdown();
		if (sceneLoader) sceneLoader.LoadScene(_targetScene);
    }
}

