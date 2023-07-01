//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: The stats are the data that are individual to an entity, for example
//  a characters name, walk speed, and special abilities would be stored here
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Entity_Stats", menuName="Neverway/ScriptableObjects/Entity/Stats")]
public class Entity_Stats : ScriptableObject
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Header("Basic Entity Values")]
    public string characterName="???";
    public RuntimeAnimatorController animationController;
    public float walkSpeed=3;
    public float runSpeed=7;
    public float maxHealth=100;
    public float invulnerabilityDuration=1;
    public List<string> entityGroups;
    [Header("3D Entity Values")] 
    public float groundDrag=6;
    public float airDrag=2;
    public float aerialControlMultiplier=0.6f;
    public float entityHeight=1;
    public float jumpForce=15;
    public float jumpCooldown = 0.25f;
    public float fallRate=32;
    public float doubleJumpForce=25;
    public int doubleJumps=0;


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

