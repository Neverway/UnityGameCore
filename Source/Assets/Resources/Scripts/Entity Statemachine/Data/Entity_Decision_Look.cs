//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using UnityEngine;

[CreateAssetMenu (menuName = "Neverway/PluggableAI/Decisions/Look")]
public class Entity_Decision_Look : Entity_Decision
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    public override bool Decide(Entity_StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }
    
    public bool Look(Entity_StateController controller)
    {
        // Awareness function here
        return true;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

