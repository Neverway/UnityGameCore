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
using UnityEngine.Audio;

public class System_ApplicaitonSettings : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public AudioMixer audioMixer;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private string targetVolumeChannel;
    private Resolution[] supportedResolutions;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_ButtonHintManager buttonHintManager;
    private UI_Debug_FPS fpsCounter;
    [SerializeField] private TMP_Dropdown displayResolutionDropdown;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    buttonHintManager = FindObjectOfType<System_ButtonHintManager>();
	    fpsCounter = FindObjectOfType<UI_Debug_FPS>();
	    supportedResolutions = Screen.resolutions;
	    displayResolutionDropdown.ClearOptions();
	    List<string> options = new List<string>();
	    int currentResolutionIndex = 0;
	    for (int i = 0; i < supportedResolutions.Length; i++)
	    {
		    string option = supportedResolutions[i].width + " x " + supportedResolutions[i].height;
		    options.Add(option);
		    if (supportedResolutions[i].width == Screen.currentResolution.width &&
		        supportedResolutions[i].height == Screen.currentResolution.height)
		    {
			    currentResolutionIndex = i;
		    }
	    }
	    displayResolutionDropdown.AddOptions(options);
	    displayResolutionDropdown.value = currentResolutionIndex;
	    displayResolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SetVolumeChannelTarget(string _channel)
    {
	    targetVolumeChannel = _channel;
    }
    
    public void SetVolume(float _level)
    {
	    audioMixer.SetFloat(targetVolumeChannel, _level);
    }

    public void SetWindowMode(int _mode)
    {
	    if (_mode == 0)
		    Screen.fullScreenMode = FullScreenMode.Windowed;
	    else if (_mode == 1)
		    Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
	    else if (_mode == 2)
		    Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
	    else
		    Screen.fullScreenMode = Screen.fullScreenMode;
    }

    public void SetDisplayResolution(int _resolutionIndex)
    {
	    Resolution resolution = supportedResolutions[_resolutionIndex];
	    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }

    public void SetButtonHintVisibility(int _hintsEnabled)
    {
	    if (_hintsEnabled == 0)
		    buttonHintManager.showButtonHints = false;
	    else
		    buttonHintManager.showButtonHints = true;
    }

    public void SetFPSCounterVisibility(int _value)
    {
	    fpsCounter.ShowFPSCounter(_value);
    }

    public void SetFpsLimit(float _limit)
    {
	    Application.targetFrameRate = Mathf.RoundToInt(_limit);
    }

    public void SetBrightness(float _level)
    {
	    Screen.brightness = _level;
    }
}

