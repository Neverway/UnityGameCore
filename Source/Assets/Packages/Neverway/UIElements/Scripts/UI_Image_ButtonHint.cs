//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Set a UI image to the current keybind, for an Input action, for a
//     specified input device
// Applied to: A UI image element that you want to display a keybind for
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Image_ButtonHint : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private string targetActionMap;
    [SerializeField] private string targetAction;
    public bool exemptFromHidingHints;
    [Header("0 = Active input device, 1 = Keyboard, 2 = Gamepad")]
    [Range(0,2)] [SerializeField] private int targetInputDevice;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Sprite targetBindingIcon;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_ButtonHintManager buttonHintManager;
    [SerializeField] private Image bindingIcon;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        buttonHintManager = FindObjectOfType<System_ButtonHintManager>();
    }

    private void Update()
    {
        if (!buttonHintManager) buttonHintManager = FindObjectOfType<System_ButtonHintManager>();
        if (!buttonHintManager) return;
        if (targetActionMap == "" || targetAction == "") return;
        if (!bindingIcon) bindingIcon = gameObject.GetComponent<Image>();
        try
        {
            targetBindingIcon = buttonHintManager.GetBindingIcon(targetInputDevice, targetActionMap, targetAction);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        if (bindingIcon && targetBindingIcon) bindingIcon.sprite = targetBindingIcon;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

