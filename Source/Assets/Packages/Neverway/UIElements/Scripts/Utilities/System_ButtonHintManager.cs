//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Handel data to return button sprite for input actions
// Applied to: The persistent system manager
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class System_ButtonHintManager : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool showButtonHints;
    public ButtonInput[] buttonInputs;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.MenuActions menuActions;
    private Input_Actions.Player2DActions player2DActions;
    private Input_Actions.Player3DActions player3DActions;
    public Sprite rebindingSprite;
    

    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    menuActions = new Input_Actions().Menu;
	    player2DActions = new Input_Actions().Player2D;
	    player3DActions = new Input_Actions().Player3D;
    }

    private void Update()
    {
	    switch (showButtonHints)
	    {
		    case true:
		    {
			    foreach (var hint in FindObjectsOfType<UI_Image_ButtonHint>(true)) hint.gameObject.SetActive(true);
			    break;
		    }
		    case false:
		    {
			    foreach (var hint in FindObjectsOfType<UI_Image_ButtonHint>(true)) if (!hint.exemptFromHidingHints) hint.gameObject.SetActive(false);
			    break;
		    }
	    }
    }

    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    [Serializable]
    public class ButtonInput
    {
	    public string bindingID;
	    public Sprite bindingIcon;
    }
    
    private InputAction GetRequestedAction(string _targetActionMap, string _targetAction)
    {
	    switch (_targetActionMap)
	    {
		    case "menu":
		    {
			    foreach (var _action in menuActions.Get().actions) if (_targetAction == _action.name) return _action;
			    break;
		    }
		    case "player2D":
		    {
			    foreach (var _action in player2DActions.Get().actions)
			    {
				    if (_targetAction == _action.name)
				    {
					    return _action;
				    }
			    }
			    break;
		    }
		    case "player3D":
		    {
			    foreach (var _action in player3DActions.Get().actions) if (_targetAction == _action.name) return _action;
			    break;
		    }
	    }

	    return null;
    }

    private int GetRequestedDevice(int _targetInputDevice)
    {
	    return _targetInputDevice switch
	    {
		    0 => 0, // replace with code to find active input device
		    1 => 0,
		    2 => 1,
		    _ => 0
	    };
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public Sprite GetBindingIcon(int _targetInputDevice, string _targetActionMap, string _targetAction)
    {
	    var requestedAction = GetRequestedAction(_targetActionMap, _targetAction);
	    var formattedAction = "";
	    if (requestedAction != null) formattedAction = requestedAction.bindings[GetRequestedDevice(_targetInputDevice)].ToString().Replace(_targetAction+":", ""); 
	    foreach (var binding in buttonInputs) { if (formattedAction == binding.bindingID) return binding.bindingIcon; }

	    return null;
    }
}
