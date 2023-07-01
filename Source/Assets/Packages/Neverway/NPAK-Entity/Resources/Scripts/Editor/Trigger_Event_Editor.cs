//========== Neverway 2023 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Trigger_Event))]
public class Trigger_Event_Editor : Editor
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

