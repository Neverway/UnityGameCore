//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Component
// Purpose: Show the character name of a specified entity
// Applied to: A UI text element that you want an entity's name to appear on
//
//=============================================================================

using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
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
    private TMP_Text textTarget;
    [SerializeField] private Entity targetEntity;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        textTarget = GetComponent<TMP_Text>();
    }
    
    private void Update()
    {
        // Update Character Name
        textTarget.text = targetEntity ? targetEntity.stats.characterName : "---";
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

