//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Component
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Menu : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Tooltip("If enabled, the menu will remain open when the 'close' menu input action is pressed")]
    [SerializeField] private bool disableCloseMenuAction;
    [Tooltip("If enabled, the menu will trigger pause and unpause game events when opened or closed (Also, only one pausing menu can be open at a time)")]
    [SerializeField] private bool pausingMenu;
    [Tooltip("If enabled, the menu will activate on Awake")]
    [SerializeField] private bool activateOnStart;
    //[Tooltip("The input action that opens the menu (Only works if 'targetMenuContainer' is not null and different from this GameObject)")]
    //[SerializeField] private InputAction openMenuButton;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool initialInputDelay;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private UnityEvent OnMenuApply;
    [SerializeField] private UnityEvent OnMenuOpen;
    [SerializeField] private UnityEvent OnMenuClose;
    [SerializeField] private GameObject targetMenuContainer;
    [SerializeField] private GameObject selectedButtonWhenOpened;
    private Input_Actions.MenuActions action;
    private System_MenuManager menuManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    action = new Input_Actions().Menu;
	    action.Enable();
	    if (activateOnStart) OpenMenu();
    }

    private void Update()
    {
	    if (initialInputDelay) return;
	    if (action.Apply.WasPressedThisFrame())
	    {
		    print("apply");
		    OnMenuApply.Invoke();
	    }
	    if (action.Close.WasPressedThisFrame() && !disableCloseMenuAction) { CloseMenu(); }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private IEnumerator InitialInputDelay()
    {
	    yield return new WaitForSeconds(0.15f);
	    initialInputDelay = false;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void OpenMenu()
    {
	    initialInputDelay = true;
	    if (targetMenuContainer) targetMenuContainer.SetActive(true);
	    EventSystem.current.SetSelectedGameObject(selectedButtonWhenOpened);
	    if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
	    if (pausingMenu && menuManager) menuManager.menuOpen = true;
	    OnMenuOpen.Invoke();
	    StartCoroutine(InitialInputDelay());
    }
    
    public void CloseMenu()
    {
	    // If the target menu container has not been selected, use the current object as the target
	    if (!targetMenuContainer) targetMenuContainer = gameObject;   
	    targetMenuContainer.SetActive(false);
	    EventSystem.current.SetSelectedGameObject(null);
	    if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
	    if (pausingMenu && menuManager) menuManager.menuOpen = false;
	    OnMenuClose.Invoke();
    }

    public void SetDisableCloseMenuAction(bool _value)
    {
	    disableCloseMenuAction = _value;
    }
}

