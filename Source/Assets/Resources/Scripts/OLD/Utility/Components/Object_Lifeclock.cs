//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Destroy a GameObject after a duration has passed
// Applied to: Any GameObject that you want to have a limited life span
//
//=============================================================================

using UnityEngine;

public class Object_Lifeclock : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private float lifetime = 1f;
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

