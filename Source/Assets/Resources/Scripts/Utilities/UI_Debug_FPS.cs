//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: Output the frames per second to a TMP_Text component
//
//=============================================================================

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
    private bool active;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private TMP_Text fpsCounterText;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Update()
    {
	    if (!active) return;
	    time += Time.deltaTime;
	    frameCount++;
	    if (time >= updateRate)
	    {
		    int frameRate = Mathf.RoundToInt(frameCount / time);
		    fpsCounterText.text = frameRate + " FPS";

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
		    active = false;
	    }
	    else
	    {
		    GetComponent<Image>().enabled = true;
		    fpsCounterText.gameObject.SetActive(true);
		    active = true;
	    }
    }
}

