//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Set Selected UI option for button based menu navigation
// Applied to: The root of a UI menu
//
//=============================================================================

using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Menu_SetFocus : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool activateOnStart;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    public GameObject firstButton;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    if (activateOnStart) Activate();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Activate()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}

