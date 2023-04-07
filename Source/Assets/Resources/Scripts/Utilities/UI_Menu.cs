using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Menu : MonoBehaviour
{
    private Input_Actions.MenuActions action;
    private System_MenuManager menuManager;
    public UnityEvent OnMenuClosed;
    
    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<System_MenuManager>();
        action = new Input_Actions().Menu;
        action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Close this menu if it's in focus
        if (action.Close.IsPressed() && menuManager.focusedMenu == gameObject)
        {
            OnMenuClosed.Invoke();
            gameObject.SetActive(false);
            menuManager.focusedMenu = null;
        }
    }

    public void SetFocus(bool _isFocused)
    {
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        if (_isFocused) menuManager.SetFocusedMenu(gameObject);
        else if (menuManager.focusedMenu == gameObject)
        {
            menuManager.focusedMenu = null;
        }
    }
}
