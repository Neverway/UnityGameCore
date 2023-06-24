//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Provide functions for finding entities with different parameters
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Entity_Referencer
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
    // Mono Functions
    //=-----------------=
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    /// <summary>
    /// Finds the player entity with an Entity_Brain_Player attached.
    /// </summary>
    /// <param name="_includeInactive">Whether to include inactive entities in the search.</param>
    /// <returns>The player entity, or null if not found.</returns>
    public Entity GetPlayerEntity(bool _includeInactive=false)
    {
        foreach (var entity in Entity.FindObjectsOfType<Entity>(_includeInactive))
        {
            if (entity.currentController is not Entity_Controller_Player) continue;
            var netEnt = entity.GetComponent<NetworkObject>();
            if (netEnt && netEnt.IsLocalPlayer) return entity;
            if (!netEnt) return entity;
        }
        
        return null;
    }
    
    /// <summary>
    /// Finds all active entities within a certain distance and/or group(s) from a specified position.
    /// </summary>
    /// <param name="_withinGroups">The list of group names to include. If null, all groups are included.</param>
    /// <param name="_withinDistance">The maximum distance to include. If zero, distance is ignored.</param>
    /// <param name="_fromPosition">The position to measure distance from. If null, the transform position is used.</param>
    /// <param name="_includeInactive">Whether to include inactive entities in the results.</param>
    /// <returns>The list of entities that meet the specified criteria.</returns>
    public List<Entity> GetEntities(List<string> _withinGroups=null, float _withinDistance=0, Vector3? _fromPosition=default, bool _includeInactive=false)
    {
        var targetEntities = new List<Entity>();
        foreach (var entity in Entity.FindObjectsOfType<Entity>(_includeInactive))
        {
            if (_fromPosition == null) _fromPosition = entity.transform.position;

            // If using range & within range
            if (_withinDistance != 0 && Vector3.Distance(_fromPosition.Value, entity.transform.position) <= _withinDistance)
            {
                // If using groups
                if (_withinDistance == 0 && _withinGroups != null)
                {
                    foreach (var group in _withinGroups)
                    {
                        if (!targetEntities.Contains(entity)) targetEntities.Add(entity);
                    }
                }

                // If not using groups
                if (!targetEntities.Contains(entity)) targetEntities.Add(entity);
            }

            // If not using range & using groups
            if (_withinDistance == 0 && _withinGroups != null)
            {
                foreach (var group in _withinGroups)
                {
                    if (!targetEntities.Contains(entity)) targetEntities.Add(entity);
                }
            }
        }

        return targetEntities;
    }

}

