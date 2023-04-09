using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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
        if (action.Close.IsPressed())
        {
            CloseMenu();
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

    public void OpenMenu()
    {
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        if (gameObject.GetComponent<UI_MenuScroll>()) gameObject.GetComponent<UI_MenuScroll>().Activate();
        else EventSystem.current.SetSelectedGameObject(null);
        gameObject.SetActive(true);
        menuManager.focusedMenu = gameObject;
    }

    public void CloseMenu()
    {
        if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
        if (menuManager.focusedMenu != gameObject) return;
        OnMenuClosed.Invoke();
        gameObject.SetActive(false);
        menuManager.focusedMenu = null;
    }
}
