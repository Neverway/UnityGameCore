//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Make a camera follow the local player entity
// Applied to: A camera object
//
//=============================================================================

using UnityEngine;

public class Camera_FollowEntity : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private Vector2 offset;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    private Entity targetEntity;
    

    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    // Find the local player controlled entity
	    targetEntity = entityReferencer.GetPlayerEntity();
	    if (!targetEntity) return;
	    
	    // Update camera position
	    var targetPosition = targetEntity.transform.position;
	    transform.position = new Vector3(
		    targetPosition.x + offset.x, 
		    targetPosition.y + offset.y, 
		    transform.position.z);
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

