//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Pause : MonoBehaviour
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
    public List<Entity> entities;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
		entities.Clear();
		foreach (var entity in FindObjectsOfType<Entity>())
		{
			entities.Add(entity);
		}

		
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void PauseGame()
    {
	    foreach (var entity in entities)
	    {
		    entity.Pause();
	    }
    }
    
    public void UnpauseGame()
    {
	    foreach (var entity in entities)
	    {
		    entity.Unpause();
	    }
    }
}

