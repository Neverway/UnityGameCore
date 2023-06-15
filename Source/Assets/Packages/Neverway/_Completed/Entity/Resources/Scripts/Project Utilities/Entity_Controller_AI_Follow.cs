//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: Chase after the closest entity that's in a specified group
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Controller_AI_Follow", menuName="Neverway/ScriptableObjects/Entity/Controller/AI_Follow")]
public class Entity_Controller_AI_Follow : Entity_Controller
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public List<string> targetedEntityGroups;
    [SerializeField] private float stoppingDistance = 1.5f;
    [SerializeField] private float awarenessDistance = 8f;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Vector2 movement;
    private Entity target;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private Entity FindClosestEntity(Entity _entity, List<Entity> _inRangeEntities)
    {
        Entity closestEntity = null;
        float closestDistance = float.MaxValue;
        foreach (var targetEntity in _inRangeEntities)
        {
            if (targetEntity == _entity) continue;
            float distanceToEntity = Vector3.Distance(_entity.transform.position, targetEntity.transform.position);
            if (distanceToEntity < closestDistance)
            {
                closestEntity = targetEntity;
                closestDistance = distanceToEntity;
            }
        }
        return closestEntity;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public override void EntityAwake(Entity entity)
    {
        
    }
    
    public override void Think(Entity entity)
    {
        // Find target
        var inRangeEntities = entityReferencer.GetEntities(targetedEntityGroups, awarenessDistance, entity.transform.position);
        target = FindClosestEntity(entity, inRangeEntities);

        // Move towards the target
        if (target && Vector2.Distance(entity.transform.position, target.transform.position) > stoppingDistance)
        {
            Vector2 direction = (target.transform.position - entity.transform.position).normalized;
            movement = direction * entity.currentMovementSpeed;
        }
        else
        {
            movement = new Vector2(0, 0);
        }

        // Set entity movement
        entity.SetMovement(movement);
    }
}

