//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Controller_Player", menuName="Neverway/ScriptableObjects/Entity/Controller/Player")]
public class Entity_Controller_Player : Entity_Controller
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Vector2 movement;
    private bool is3DEntity;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.Player2DActions player2DActions;
    private Input_Actions.Player3DActions player3DActions;
    private Entity_Interact entityInteract;
    private Entity_Look3D entityLook;
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    public override void EntityAwake(Entity entity)
    {
        GetEntityDimensionType(entity);
        entityInteract = entity.GetComponent<Entity_Interact>();
        entityLook = entity.GetComponent<Entity_Look3D>();
    }
    
    public override void Think(Entity entity)
    {
        // Check if entity is a network entity, and if so, make sure we only control the local one
        //if (!entity.netObject) entity.netObject = entity.GetComponent<NetworkObject>();
        //if (entity.netObject) if (!entity.netObject.IsOwner) return;

        // Horizontal Movement
        if (player2DActions.MoveLeft.IsPressed() || player3DActions.MoveLeft.IsPressed()) movement.x = -1;
        else if (player2DActions.MoveRight.IsPressed() || player3DActions.MoveRight.IsPressed()) movement.x = 1;
        else movement.x = 0;
        
        // Vertical Movement
        if (player2DActions.MoveUp.IsPressed() || player3DActions.MoveUp.IsPressed()) movement.y = 1;
        else if (player2DActions.MoveDown.IsPressed() || player3DActions.MoveDown.IsPressed()) movement.y = -1;
        else movement.y = 0;
        
        // Sprinting
        if (player2DActions.Action.WasPressedThisFrame() || player3DActions.LS.WasPressedThisFrame()) entity.SetSprinting(true);
        if (player2DActions.Action.WasReleasedThisFrame() || player3DActions.LS.WasReleasedThisFrame()) entity.SetSprinting(false);
        
        // Interact
        if (entityInteract)
            if (player2DActions.Interact.WasPressedThisFrame() || player3DActions.Interact.WasPressedThisFrame())
                entityInteract.Interact();
        
        // Look (3D only)
        if (entityLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            // Horizontal Movement
            Debug.Log(player3DActions.LookHorizontal.ReadValue<float>().ToString());
            if (player3DActions.LookLeft.IsPressed()) entityLook.xInput = -1;
            else if (player3DActions.LookRight.IsPressed()) entityLook.xInput = 1;
            else entityLook.xInput = 0;
            entityLook.xInputAlternate = player3DActions.LookHorizontal.ReadValue<float>()*0.02f;
        
            // Vertical Movement
            if (player3DActions.LookUp.IsPressed()) entityLook.yInput = 1;
            else if (player3DActions.LookDown.IsPressed()) entityLook.yInput = -1;
            else entityLook.yInput = 0;
            entityLook.yInputAlternate = player3DActions.LookVertical.ReadValue<float>()*0.02f;
        }
        
        // Jump (3D only)
        if (is3DEntity)
        {
            if (player3DActions.Action.WasPressedThisFrame()) entity.Jump3D();
        }
        
        
        // Set entity movement
        entity.SetMovement(movement);
    }

    private void GetEntityDimensionType(Entity _entity)
    {
        player2DActions = new Input_Actions().Player2D;
        player3DActions = new Input_Actions().Player3D;
        if (_entity.GetComponent<Rigidbody2D>())
        {
            is3DEntity = false;
            player2DActions.Enable();
        }
        else if (_entity.GetComponent<Rigidbody>())
        {
            is3DEntity = true;
            player3DActions.Enable();
        }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

