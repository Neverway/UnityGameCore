//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Brain_AI", menuName="Neverway/ScriptableObjects/Entity_Brains/Entity_Brain_AI")]
public class Entity_Brain_AI : Entity_Brain
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
        entity.target = FindClosestEntity(entity, inRangeEntities);

        // Move towards the target
        if (entity.target && Vector2.Distance(entity.transform.position, entity.target.transform.position) > stoppingDistance)
        {
            Vector2 direction = (entity.target.transform.position - entity.transform.position).normalized;
            movement = direction * entity.currentSpeed;
        }
        else
        {
            movement = new Vector2(0, 0);
        }

        // Set entity movement
        entity.SetMovement(movement);
    }
}

