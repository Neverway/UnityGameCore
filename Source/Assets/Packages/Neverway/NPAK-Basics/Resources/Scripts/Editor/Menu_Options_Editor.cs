//========== Neverway 2023 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================


using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Menu_Options))]
public class Menu_Options_Editor : Editor
{
    public VisualTreeAsset UXML;
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        UXML.CloneTree(root);
        return root;
    }
}
