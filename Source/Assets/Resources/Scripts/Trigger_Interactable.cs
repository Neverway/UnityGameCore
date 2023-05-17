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
using UnityEngine.Events;

public class Trigger_Interactable : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool toggled;
    public UnityEvent OnInteract;
    public UnityEvent OnUntoggled;
    public UnityEvent OnToggled;


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
    private void OnTriggerEnter2D(Collider2D other)
    {
	    Debug.Log("Nate is a bastard");
	    if (!other.GetComponent<Trigger_Interaction>()) return;

	    Interact();
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    private void Interact()
    {
	    OnInteract.Invoke();
	    toggled = !toggled;
	    switch (toggled)
	    {
		    case true:
			    OnToggled.Invoke();
			    break;
		    case false:
			    OnUntoggled.Invoke();
			    break;
	    }
    }
}

