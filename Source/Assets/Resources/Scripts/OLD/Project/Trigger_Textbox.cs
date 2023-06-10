//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Textbox : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public List<Textbox_Data> textboxData;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Menu_Textbox textboxManager;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    public void Awake()
    {
        textboxManager = FindObjectOfType<Menu_Textbox>();
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Activate()
    {
        if (textboxManager.textboxOpen) return;
        textboxManager.PrintText(textboxData);
    }
}

