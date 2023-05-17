//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Destroy a GameObject after a duration has passed
// Applied to: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Lifeclock : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public float lifetime = 1f;
    [SerializeField] private bool startClockOnAwake;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    if (startClockOnAwake) StartClock();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void StartClock()
    {
        Destroy(gameObject, lifetime);
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

