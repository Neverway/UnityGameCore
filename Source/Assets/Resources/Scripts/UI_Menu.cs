//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Set Selected UI option for button based menu navigation
// Applied to: The root of a UI menu
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Menu : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Tooltip("Is this menu already open when scene loads? (This is only really used for things like the game over and title scenes.)")]
    public bool activateOnStart;
    public bool disableCloseMenuAction;
    public UnityEvent OnMenuClosed;
    public UnityEvent OnMenuApply;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.MenuActions action;
    private System_MenuManager menuManager;
    [Tooltip("The button that is selected by default when this menu is opened")]
    public GameObject firstButton;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        // Initialize menu input actions
        action = new Input_Actions().Menu;
        action.Enable();
        // Find object references
        menuManager = FindObjectOfType<System_MenuManager>();
        // Active the menu when scene loads (if true)
        if (activateOnStart) Activate();
    }
    
    void Update()
    {
        /* This doesn't work because menuManager.focusedMenu only contains menu root objects
        // Don't allow the menu to close or apply if we're typing in an input field
        var inputField = menuManager.focusedMenuElement.GetComponent<TMP_InputField>();
        if (inputField) return;*/
        
        // Close/Apply this menu if it's in focus
        if (menuManager.focusedMenu != gameObject) return;
        if (action.Close.IsPressed() && !disableCloseMenuAction) { CloseMenu(); }
        if (action.Apply.IsPressed()) { OnMenuApply.Invoke(); }
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void Activate()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    /*
    public void SetFocus(bool _isFocused)
    {
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        if (_isFocused) menuManager.SetFocusedMenu(gameObject);
        else if (menuManager.focusedMenu == gameObject) { menuManager.focusedMenu = null; }
    }*/

    public void OpenMenu()
    {
        // Fixes occasional Null reference caused by script being on a persistent singleton
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        //if (gameObject.GetComponent<UI_Menu_SetFocus>()) gameObject.GetComponent<UI_Menu_SetFocus>().Activate();
        Activate();
        menuManager.focusedMenu = gameObject;
        gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        // Fixes occasional Null reference caused by script being on a persistent singleton
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        //if (menuManager.focusedMenuElement != gameObject) return;
        OnMenuClosed.Invoke();
        menuManager.focusedMenu = null;
        gameObject.SetActive(false);
    }
}
