//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Component
// Purpose: Output the value of the project version to a TMP_Text component
//
//=============================================================================

using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
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
        tmpText.text = Application.version;
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

