//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Remove health from an entity (or add health if the value on
//	the trigger is negative)
// Applied to: A 2D damage trigger
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

public class Trigger_Damage : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private float damageAmount;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool inTrigger;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private List<Entity> entitiesInTrigger = new List<Entity>();


    //=-----------------=
    // Mono Functions
    //=-----------------=

    private void Update()
    {
	    foreach (var entity in entitiesInTrigger)
	    {
		    entity.AddHealth(-damageAmount);
	    }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if(!entitiesInTrigger.Contains(targetEnt))
	    {
		    entitiesInTrigger.Add(targetEnt);
	    }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if(entitiesInTrigger.Contains(targetEnt))
	    {
		    entitiesInTrigger.Remove(targetEnt);
	    }
    }

    private void OnTriggerEnter(Collider other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if(!entitiesInTrigger.Contains(targetEnt))
	    {
		    entitiesInTrigger.Add(targetEnt);
	    }
    }

    private void OnTriggerExit(Collider other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if(entitiesInTrigger.Contains(targetEnt))
	    {
		    entitiesInTrigger.Remove(targetEnt);
	    }
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

