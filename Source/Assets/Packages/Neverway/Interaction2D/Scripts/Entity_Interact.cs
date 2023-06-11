//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Entity_Interact : MonoBehaviour
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
    private Input_Actions.Player2DActions player2DActions;
    private Entity entity;
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    [SerializeField] private GameObject interactionPrefab; 


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        player2DActions = new Input_Actions().Player2D;
        player2DActions.Enable();
        entity = GetComponent<Entity>();
    }

    private void Update()
    {
        if (entity != entityReferencer.GetPlayerEntity()) return;
        if (player2DActions.Interact.WasPressedThisFrame()) Interact();
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Interact()
    {
        // Get interaction direction
        var directionalRotation = entity.facingDirection.y switch
        {
            1 => 0,
            -1 => 180,
            _ => entity.facingDirection.x switch
            {
                1 => -90,
                -1 => 90,
                _ => 0
            }
        };
        
        // Create interaction trigger
        var interactionTrigger = Instantiate(interactionPrefab, transform.position, Quaternion.Euler(0, 0, directionalRotation));
        interactionTrigger.GetComponent<Trigger_Interaction>().targetEntity = entity;
        Destroy(interactionTrigger, 0.15f);
    }
}

