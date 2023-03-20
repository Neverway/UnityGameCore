//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
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
    public Input_Actions.MenuActions MenuAction;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    MenuAction = new Input_Actions().Menu;
	    MenuAction.Enable();
    }

    private void Update()
    {
	    print(MenuAction);
	    //if (MenuAction.Interact.triggered) print("1");
	    if (MenuAction.Interact.IsPressed()) print("Pressing");
	    //if (MenuAction.Interact.triggered) print("3");
	    //if (MenuAction.Interact.IsInProgress()) print("4");
	    if (MenuAction.Interact.WasPerformedThisFrame()) print("Pressed1");
	    if (MenuAction.Interact.WasPressedThisFrame()) print("Pressed");
	    if (MenuAction.Interact.WasReleasedThisFrame()) print("Released");
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

