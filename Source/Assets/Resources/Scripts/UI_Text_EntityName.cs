//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Show the health of the local player controlled entity
// Applied to: A entity name UI element
//
//=============================================================================

using TMPro;
using UnityEngine;

public class UI_Text_EntityName : MonoBehaviour
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
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    private Entity targetEntity;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    // Find the local player controlled entity
	    targetEntity = entityReferencer.GetPlayerEntity();
		
	    // Update entity name
	    GetComponent<TMP_Text>().text = targetEntity ? targetEntity.stats.characterName : "---";
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

