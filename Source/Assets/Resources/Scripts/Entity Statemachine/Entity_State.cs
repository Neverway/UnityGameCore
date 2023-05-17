//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using UnityEngine;

[CreateAssetMenu (menuName = "Neverway/PluggableAI/State")]
public class Entity_State : ScriptableObject
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Entity_Action[] actions;
    public Entity_Transition[] transitions;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void UpdateState(Entity_StateController controller)
    {
	    DoActions(controller);
	    CheckTransitions(controller);
    }
    
    public void DoActions(Entity_StateController controller)
    {
	    for (int i = 0; i < actions.Length; i++)
	    {
		    actions[i].Act(controller);
	    }
    }

    private void CheckTransitions(Entity_StateController controller)
    {
	    for (int i = 0; i < transitions.Length; i++)
	    {
		    bool decisionSucceeded = transitions[i].decision.Decide(controller);
		    if (decisionSucceeded)
		    {
			    controller.TransitionToState(transitions[i].trueState);
		    }
		    else
		    {
			    controller.TransitionToState(transitions[i].falseState);
		    }
	    }
    }
}

