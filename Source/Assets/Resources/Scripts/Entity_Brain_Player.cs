//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using Unity.Netcode;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Brain_Player", menuName="Neverway/ScriptableObjects/Entity_Brains/Entity_Brain_Player")]
public class Entity_Brain_Player : Entity_Brain
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Vector2 movement;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.Player2DActions action;
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    public override void EntityAwake(Entity entity)
    {
        action = new Input_Actions().Player2D;
        action.Enable();
    }
    
    public override void Think(Entity entity)
    {
        // Check if entity is a network entity, and if so, make sure we only control the local one
        if (!entity.netObject) entity.netObject = entity.GetComponent<NetworkObject>();
        if (entity.netObject) if (!entity.netObject.IsOwner) return;

        // Horizontal Movement
        if (action.MoveLeft.IsPressed()) movement.x = -1;
        else if (action.MoveRight.IsPressed()) movement.x = 1;
        else movement.x = 0;
        
        // Vertical Movement
        if (action.MoveUp.IsPressed()) movement.y = 1;
        else if (action.MoveDown.IsPressed()) movement.y = -1;
        else movement.y = 0;
        
        // Sprinting
        if (action.Action.WasPressedThisFrame()) entity.SetSprinting(true);
        if (action.Action.WasReleasedThisFrame()) entity.SetSprinting(false);
        
        // Interact
        if (action.Interact.WasPressedThisFrame()) entity.Interact();
        
        // Set entity movement
        entity.SetMovement(movement);
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

