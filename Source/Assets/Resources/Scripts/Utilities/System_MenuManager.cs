using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_MenuManager : MonoBehaviour
{
    public GameObject focusedMenu;

    public void SetFocusedMenu(GameObject _menuObject)
    {
        focusedMenu = _menuObject;
    }
}