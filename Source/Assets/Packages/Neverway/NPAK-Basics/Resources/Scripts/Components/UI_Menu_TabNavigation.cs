//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Component
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Menu_TabNavigation : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public UnityEvent[] indexChangeEvents;
    public int currentIndex;


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.MenuActions action;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        action = new Input_Actions().Menu;
        action.Enable();
    }

    private void Update()
    {
        if (action.TabLeft.WasPressedThisFrame())
        {
            if (currentIndex != 0)
            {
                currentIndex--;
                indexChangeEvents[currentIndex].Invoke();
            }
        }
        if (action.TabRight.WasPressedThisFrame())
        {
            if (currentIndex != indexChangeEvents.Length-1)
            {
                currentIndex++;
                indexChangeEvents[currentIndex].Invoke();
                
            }
        }
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=


    //=-----------------=
    // External Functions
    //=-----------------=
}

