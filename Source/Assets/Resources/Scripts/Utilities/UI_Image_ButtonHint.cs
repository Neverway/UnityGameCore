//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using UnityEngine;
using UnityEngine.UI;

public class UI_Image_ButtonHint : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private string targetActionMap;
    [SerializeField] private string targetAction;
    [Header("0 = Active input device, 1 = Keyboard, 2 = Gamepad")]
    [Range(0,2)] [SerializeField] private int targetInputDevice;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
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
        if (targetActionMap == "" || targetAction == "") return;
        if (!bindingIcon) bindingIcon = gameObject.GetComponent<Image>();
        var targetBindingIcon = buttonHintManager.GetBindingIcon(targetInputDevice, targetActionMap, targetAction);
        if (bindingIcon && targetBindingIcon) bindingIcon.sprite = targetBindingIcon;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

