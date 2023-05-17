//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Output the value of the project version to a TMP_Text component
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

