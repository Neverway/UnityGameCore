//========== Neverway 2023 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================


using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(System_ButtonHintManager))]
public class System_ButtonHintManager_Editor : Editor
{
    [SerializeField]
    public VisualTreeAsset UXML;
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        UXML.CloneTree(root);
        return root;
    }
}