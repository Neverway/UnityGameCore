//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Set the UI element to focus the view on when using UI_Menu_Focus_ScrollView
// Applied to: A focusable UI option
//
//=============================================================================

using UnityEngine;

public class UI_Menu_SelectableFocusElement : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Header("0 = Self, 1 = Parent")]
    [Range(0,1)] public int focusTarget;


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
    public RectTransform GetFocusTarget()
    {
        return focusTarget switch
        {
            0 => GetComponent<RectTransform>(),
            1 => transform.parent.GetComponent<RectTransform>(),
            _ => null
        };
    }
}
