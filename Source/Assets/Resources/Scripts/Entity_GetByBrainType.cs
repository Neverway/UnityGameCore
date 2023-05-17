//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

public class Entity_GetByBrainType : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public Entity_Brain targetBrainType;
    [Tooltip("(Optional) Only return entities that are in these groups")]
    public List<string> entityGroups;


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=
    [Header("Reference Variables")]
    public Entity entityTarget;

    private Entity_Referencer entityReferencer;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    foreach (var entity in FindObjectsOfType<Entity>())
	    {
		    if (entity.brain == targetBrainType)
		    {
			    if (entityGroups.Count > 0)
			    {
				    foreach (var group in entity.stats.entityGroups)
				    {
					    if (entityGroups.Contains(group)) continue; 
					    entityTarget = entity; 
					    return;
				    }
			    }
			    else
			    {
				    entityTarget = entity; 
				    return;
			    }
		    }

		    entityTarget = null; // Remove entity target if none was found
	    }
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

