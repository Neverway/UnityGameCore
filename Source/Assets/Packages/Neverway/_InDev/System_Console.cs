//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class System_Console
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private readonly string prefix;
    private readonly IEnumerable<System_Console_Command> commands;
    
    
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
    public System_Console(string _prefix, IEnumerable<System_Console_Command> _commands)
    {
        this.prefix = _prefix;
        this.commands = _commands;
    }
    
    public void ProcessCommand(string _commandInput)
    {
        if (!_commandInput.StartsWith(prefix)) { return; }

        _commandInput = _commandInput.Remove(0, prefix.Length);

        string[] inputSplit = _commandInput.Split(" ");

        string commandInput = inputSplit[0];
        string[] args = inputSplit.Skip(1).ToArray();
        
        ProcessCommand(commandInput, args);
    }
    
    public void ProcessCommand(string _commandInput, string[] _arguments)
    {
        foreach (var command in commands)
        {
            if (!_commandInput.Equals(command.Command, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            if (command.Process(_arguments))
            {
                return;
            }
        }
    }
}

