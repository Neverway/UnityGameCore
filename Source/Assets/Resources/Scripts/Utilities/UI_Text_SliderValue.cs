//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Output the value of a slider to a TMP_Text component
//
//=============================================================================

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Text_SliderValue : MonoBehaviour
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
    [SerializeField] private Slider slider;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    tmpText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
	    if (!tmpText || !slider) return;
	    tmpText.text = slider.value.ToString();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

