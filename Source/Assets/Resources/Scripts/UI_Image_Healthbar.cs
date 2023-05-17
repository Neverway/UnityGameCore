//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Show the health of the local player controlled entity
// Applied to: A health-bar UI element
//
//=============================================================================

using UnityEngine;
using UnityEngine.UI;

public class UI_Image_Healthbar : MonoBehaviour
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
	    
	    // Update health-bar
	    if (targetEntity) GetComponent<Image>().fillAmount = targetEntity.currentHealth / targetEntity.stats.maxHealth;
	    else GetComponent<Image>().fillAmount = 0;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

