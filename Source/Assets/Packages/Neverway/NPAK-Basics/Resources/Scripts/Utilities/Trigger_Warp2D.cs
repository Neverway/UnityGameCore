//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Teleport an entity to a specified exit position
// Applied to: A 2D warp trigger
//
//=============================================================================

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Trigger_Warp_2D : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private Vector3 exitOffset;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private Transform exitPosition;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void OnDrawGizmos()
    {
	    if (!exitPosition) return;
	    Gizmos.color = new Color(0.4f,0.4f,0.4f, 0.2f);
	    Gizmos.DrawLine(transform.position, exitPosition.position+exitOffset);
	    Gizmos.DrawIcon(exitPosition.position+exitOffset, "trigger_warp_exit.png",false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    other.gameObject.transform.parent.transform.position = exitPosition.position+exitOffset;
    }
    

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

