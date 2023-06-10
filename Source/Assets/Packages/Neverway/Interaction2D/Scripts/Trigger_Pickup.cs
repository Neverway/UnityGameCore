//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
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

public class Trigger_Pickup : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private Item item;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Trigger_Interactable interactable;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	
    }

    private void Update()
    {
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void PickupItem()
    {
	    /*
	    interactable = GetComponent<Trigger_Interactable>();
	    for (int i = 0; i < interactable.targetEntity.inventory.Count; i++)
	    {
		    if (interactable.targetEntity.inventory[i] == null)
		    {
			    interactable.targetEntity.inventory[i] = item;
			    Destroy(transform.parent.gameObject);
			    return;
		    }
	    }*/
    }
}

