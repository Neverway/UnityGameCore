//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Item_Defense", menuName="Neverway/ScriptableObjects/Item/Defense")]
public class Item_Defense : Item
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public int baseDefense;
    public float resistanceMultiplier;
    public float effectiveMultiplier;
    public List<string> resistantDamageTypes;
    public List<string> effectiveDamageTypes;


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

