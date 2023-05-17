//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using UnityEngine;

public class Entity_StateController : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Entity_State currentState;
    public Entity_State remainState;


    //=-----------------=
    // Private Variables
    //=-----------------=
    public bool aiActive;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
		if (!aiActive) return;
		currentState.UpdateState(this);
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=
    public void TransitionToState(Entity_State nextState)
    {
	    if (nextState != remainState)
	    {
		    currentState = nextState;
	    }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

