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
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Debug_FPS : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private float updateRate = 1f;
    private float time;
    private float frameCount;
    private bool enabled;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private TMP_Text fpsCounterText;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	
    }

    private void Update()
    {
	    if (!enabled) return;
	    time += Time.deltaTime;
	    frameCount++;
	    if (time >= updateRate)
	    {
		    int frameRate = Mathf.RoundToInt(frameCount / time);
		    fpsCounterText.text = frameRate.ToString() + " FPS";

		    time -= updateRate;
		    frameCount = 0;
	    }
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void ShowFPSCounter(int _value)
    {
	    if (_value == 0)
	    {
		    GetComponent<Image>().enabled = false;
		    fpsCounterText.gameObject.SetActive(false);
		    enabled = false;
	    }
	    else
	    {
		    GetComponent<Image>().enabled = true;
		    fpsCounterText.gameObject.SetActive(true);
		    enabled = true;
	    }
    }
}

