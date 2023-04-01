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
using UnityEngine.EventSystems;

public class UI_MenuScroll : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool activateOnStart;


    //=-----------------=
    // Private Variables
    //=-----------------=
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    public GameObject firstButton;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    if (activateOnStart) Activate();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void Activate()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    
    public void Deactivate()
    {
        //EventSystem.current.SetSelectedGameObject(null);
    }
}

