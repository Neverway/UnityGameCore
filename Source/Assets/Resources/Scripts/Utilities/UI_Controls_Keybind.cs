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

public class UI_Controls_Keybind : MonoBehaviour
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
    private Input_Actions.MenuActions action;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    action = new Input_Actions().Menu;
	    action.Enable();
    }

    private void Update()
    {
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void RebindKey()
    {
	    
    }
}

