//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Trigger_Interactable))]
public class Trigger_Interactable_Editor : Editor
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public VisualTreeAsset UXML;
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        UXML.CloneTree(root);
        return root;
    }


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

