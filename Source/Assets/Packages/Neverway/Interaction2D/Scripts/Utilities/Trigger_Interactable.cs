//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Fire events when activated by a trigger event
// Applied to: An interactable trigger
//
//=============================================================================

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
    public Entity targetEntity;


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
	    var interaction = other.GetComponent<Trigger_Interaction>();
	    if (!interaction) return;
	    targetEntity = interaction.targetEntity;
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

