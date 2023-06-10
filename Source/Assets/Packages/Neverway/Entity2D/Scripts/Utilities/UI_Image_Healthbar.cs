//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Show the health of a specified entity
// Applied to: A UI image element that you want an entity's health to appear on
//
//=============================================================================

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
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
    private Image imageTarget;
    [SerializeField] private Entity targetEntity;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        imageTarget = GetComponent<Image>();
    }

    private void Update()
    {
        // Update Health Bar
        if (targetEntity) imageTarget.fillAmount = targetEntity.currentHealth / targetEntity.stats.maxHealth;
        else imageTarget.fillAmount = 0;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

