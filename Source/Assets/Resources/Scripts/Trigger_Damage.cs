//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Util;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
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

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

