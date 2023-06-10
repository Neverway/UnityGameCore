//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Fire events when an entity has entered the trigger
// Applied to: An event trigger
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Event : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool activated;
    [Header("1 = Any entity, 2 = Only local player")]
    [Range(1,2)]public int targetType;
    [Tooltip("Invoked when an entity has entered the trigger")]
    public UnityEvent OnTriggered;
    [Tooltip("Invoked when an entity has left the trigger")]
    public UnityEvent OnExited;
    [Tooltip("Invoked when all entities have left the trigger")]
    public UnityEvent OnAllExited;


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    private List<Entity> entitiesInTrigger = new List<Entity>();


    //=-----------------=
    // Mono Functions
    //=-----------------=
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity") || activated) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if (!targetEnt) return;
	    if (targetType == 1 || targetType == 2 && targetEnt == entityReferencer.GetPlayerEntity())
	    {
		    if (!entitiesInTrigger.Contains(targetEnt)) entitiesInTrigger.Add(targetEnt);
		    Interact();
	    } 
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity") || !activated) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if (!targetEnt) return;
	    if (targetType == 1 || targetType == 2 && targetEnt == entityReferencer.GetPlayerEntity())
	    {
		    if (entitiesInTrigger.Contains(targetEnt))
		    {
			    OnExited.Invoke();
			    entitiesInTrigger.Remove(targetEnt);
			    if (entitiesInTrigger.Count == 0) OnAllExited.Invoke();
		    }
	    } 
    }
    
    private void Interact()
    {
	    activated = true;
	    OnTriggered.Invoke();
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Reactivate()
    {
	    activated = false;
    }
}

