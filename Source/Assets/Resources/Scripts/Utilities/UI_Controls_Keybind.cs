//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_Controls_Keybind : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private string targetActionMap;
    [SerializeField] private string targetAction;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool listeningForInput;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_ButtonHintManager buttonHintManager;
    private UI_Image_ButtonHint buttonHint;
    private Input_Actions.MenuActions menuActions;
    private Input_Actions.Player2DActions player2DActions;
    private Input_Actions.Player3DActions player3DActions;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    buttonHintManager = FindObjectOfType<System_ButtonHintManager>();
	    buttonHint = gameObject.GetComponent<UI_Image_ButtonHint>();
	    menuActions = new Input_Actions().Menu;
	    player2DActions = new Input_Actions().Player2D;
	    player3DActions = new Input_Actions().Player3D;
    }

    private void Update()
    {
		if (!listeningForInput) return;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private IEnumerator WaitingForInput()
    {
	    yield return new WaitForSeconds(0.2f);
	    
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void RebindKey()
    {
	    // Set image to 'press a key' prompt
	    buttonHint.enabled = false;
	    GetComponent<Image>().sprite = buttonHintManager.rebindingSprite;
	    // Start listening for input
	    StartCoroutine(WaitingForInput());
    }
}

