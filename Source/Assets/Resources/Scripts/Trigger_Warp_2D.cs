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
    private void Start()
    {
	
    }

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

    private void OnTriggerExit(Collider other)
    {
	    
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

