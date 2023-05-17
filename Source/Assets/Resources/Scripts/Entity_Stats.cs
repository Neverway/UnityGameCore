//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Stats", menuName="Neverway/ScriptableObjects/Entity_Stats")]
public class Entity_Stats : ScriptableObject
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public string characterName="???";
    public RuntimeAnimatorController animationController;
    public float walkSpeed=3;
    public float runSpeed=7;
    public float maxHealth=100;
    public float invulnerabilityDuration=1;
    public List<string> entityGroups;


    //=-----------------=
    // Private Variables
    //=-----------------=


    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Internal Functions
    //=-----------------=


    //=-----------------=
    // External Functions
    //=-----------------=
}

