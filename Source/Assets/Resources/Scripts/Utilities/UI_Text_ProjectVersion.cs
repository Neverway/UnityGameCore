//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using TMPro;
using UnityEngine;

public class UI_Text_ProjectVersion : MonoBehaviour
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
    private TMP_Text tmpText;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
	    if (!tmpText) return;
	    tmpText.text = Application.version;
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

