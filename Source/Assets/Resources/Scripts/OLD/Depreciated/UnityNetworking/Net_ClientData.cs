//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Store things like the player name and selected character
// Applied to: The system manager
// Notes: This works as a more reliable alternative to using player prefs
//
//=============================================================================

using System;
using UnityEngine;

public class Net_ClientData : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public string netUsername;
    public int netCharacter;
    public Character[] characters;


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
    [Serializable]
    public class Character
    {
        public Entity_Stats characterStats;
        public RuntimeAnimatorController characterAnimator;
    }
}

