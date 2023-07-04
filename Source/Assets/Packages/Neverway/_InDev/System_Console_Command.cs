//========== Neverway 2023 Project Script | Written by Unknown Dev ============
// 
// Type: 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class System_Console_Command : ScriptableObject, System_Console_CommandInterface
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private string command = String.Empty;
    
    public string Command => command;

    public abstract bool Process(string[] _arguments);


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=


    //=-----------------=
    // Internal Functions
    //=-----------------=


    //=-----------------=
    // External Functions
    //=-----------------=
}

