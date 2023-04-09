//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class System_ApplicationSettings : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public AudioMixer audioMixer;
    public AppSettings defaultSettings;
    public AppSettings currentSettings;
    public AppSettings savedSettings;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Resolution[] supportedResolutions;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	    // load the stored settings here
	    supportedResolutions = Screen.resolutions;
	    defaultSettings.displayResolution = supportedResolutions.Length-1;
	    LoadApplicationSettings();
	    UpdateApplicationSetting("all");
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    [Serializable]
    public class AppSettings
    {
	    [Header("Graphics")]
	    public int displayResolution;
	    public int windowMode;
	    public int fpsCounter;
	    public float fpsLimit;
	    public float brightness;
	    [Header("Quality")]
	    public int lightingQuality;
	    public int shadowQuality;
	    public int textureQuality;
	    public int postProcessingQuality;
	    public int antiAliasing;
	    public int levelOfDetail;
	    public int ambientOcclusion;
	    public int bloom;
	    public int motionBlur;
	    [Header("Sound")]
	    public float master;
	    public float music;
	    public float soundEffects;
	    public float voiceChat;
	    public float characterChatter;
	    public float ambient;
	    public float menus;
	    [Header("Gameplay")] 
	    public float verticalLookSensitivity;
	    public float horizontalLookSensitivity;
	    public float fieldOfView;
	    public int buttonHints;
	    public int gameChat;
    }
    // Fires when first loading the options menu in a scene
    private void LoadApplicationSettings()
    {
	    // Graphics
	    currentSettings.displayResolution = PlayerPrefs.GetInt("displayResolution", defaultSettings.displayResolution);
	    currentSettings.windowMode = PlayerPrefs.GetInt("windowMode", defaultSettings.windowMode);
	    currentSettings.fpsCounter = PlayerPrefs.GetInt("fpsCounter", defaultSettings.fpsCounter);
	    currentSettings.fpsLimit = PlayerPrefs.GetFloat("fpsLimit", defaultSettings.fpsLimit);
	    currentSettings.brightness = PlayerPrefs.GetFloat("brightness", defaultSettings.brightness);
	    // Quality
	    currentSettings.lightingQuality = PlayerPrefs.GetInt("lightingQuality", defaultSettings.lightingQuality);
	    currentSettings.shadowQuality = PlayerPrefs.GetInt("shadowQuality", defaultSettings.shadowQuality);
	    currentSettings.textureQuality = PlayerPrefs.GetInt("textureQuality", defaultSettings.textureQuality);
	    currentSettings.postProcessingQuality = PlayerPrefs.GetInt("postProcessingQuality", defaultSettings.postProcessingQuality);
	    currentSettings.antiAliasing = PlayerPrefs.GetInt("antiAliasing", defaultSettings.antiAliasing);
	    currentSettings.levelOfDetail = PlayerPrefs.GetInt("levelOfDetail", defaultSettings.levelOfDetail);
	    currentSettings.ambientOcclusion = PlayerPrefs.GetInt("ambientOcclusion", defaultSettings.ambientOcclusion);
	    currentSettings.bloom = PlayerPrefs.GetInt("bloom", defaultSettings.bloom);
	    currentSettings.motionBlur = PlayerPrefs.GetInt("motionBlur", defaultSettings.motionBlur);
	    // Sound
	    currentSettings.master = PlayerPrefs.GetFloat("master", defaultSettings.master);
	    currentSettings.music = PlayerPrefs.GetFloat("music", defaultSettings.music);
	    currentSettings.soundEffects = PlayerPrefs.GetFloat("soundEffects", defaultSettings.soundEffects);
	    currentSettings.voiceChat = PlayerPrefs.GetFloat("voiceChat", defaultSettings.voiceChat);
	    currentSettings.characterChatter = PlayerPrefs.GetFloat("characterChatter", defaultSettings.characterChatter);
	    currentSettings.ambient = PlayerPrefs.GetFloat("ambient", defaultSettings.ambient);
	    currentSettings.menus = PlayerPrefs.GetFloat("menus", defaultSettings.menus);
	    // Gameplay
	    currentSettings.verticalLookSensitivity = PlayerPrefs.GetFloat("verticalLookSensitivity", defaultSettings.verticalLookSensitivity);
	    currentSettings.horizontalLookSensitivity = PlayerPrefs.GetFloat("horizontalLookSensitivity", defaultSettings.horizontalLookSensitivity);
	    currentSettings.fieldOfView = PlayerPrefs.GetFloat("fieldOfView", defaultSettings.fieldOfView);
	    currentSettings.buttonHints = PlayerPrefs.GetInt("buttonHints", defaultSettings.buttonHints);
	    currentSettings.gameChat = PlayerPrefs.GetInt("gameChat", defaultSettings.gameChat);
	    
	    PlayerPrefs.Save();
    }

/*
    // Fires when first loading the options menu in a scene
    private void SaveCurrentSettings()
    {
	    // Graphics
	    PlayerPrefs.SetInt("displayResolution", currentSettings.displayResolution);
	    PlayerPrefs.SetInt("windowMode", currentSettings.windowMode);
	    PlayerPrefs.SetInt("fpsCounter", currentSettings.fpsCounter);
	    PlayerPrefs.SetFloat("fpsLimit", currentSettings.fpsLimit);
	    PlayerPrefs.SetFloat("brightness", currentSettings.brightness);
	    // Quality
	    PlayerPrefs.SetInt("lightingQuality", currentSettings.lightingQuality);
	    PlayerPrefs.SetInt("shadowQuality", currentSettings.shadowQuality);
	    PlayerPrefs.SetInt("textureQuality", currentSettings.textureQuality);
	    PlayerPrefs.SetInt("postProcessingQuality", currentSettings.postProcessingQuality);
	    PlayerPrefs.SetInt("antiAliasing", currentSettings.antiAliasing);
	    PlayerPrefs.SetInt("levelOfDetail", currentSettings.levelOfDetail);
	    PlayerPrefs.SetInt("ambientOcclusion", currentSettings.ambientOcclusion);
	    PlayerPrefs.SetInt("bloom", currentSettings.bloom);
	    PlayerPrefs.SetInt("motionBlur", currentSettings.motionBlur);
	    // Sound
	    PlayerPrefs.SetFloat("master", currentSettings.master);
	    PlayerPrefs.SetFloat("music", currentSettings.music);
	    PlayerPrefs.SetFloat("soundEffects", currentSettings.soundEffects);
	    PlayerPrefs.SetFloat("voiceChat", currentSettings.voiceChat);
	    PlayerPrefs.SetFloat("characterChatter", currentSettings.characterChatter);
	    PlayerPrefs.SetFloat("ambient", currentSettings.ambient);
	    PlayerPrefs.SetFloat("menus", currentSettings.menus);
	    // Gameplay
	    PlayerPrefs.SetFloat("verticalLookSensitivity", currentSettings.verticalLookSensitivity);
	    PlayerPrefs.SetFloat("horizontalLookSensitivity", currentSettings.horizontalLookSensitivity);
	    PlayerPrefs.SetFloat("fieldOfView", currentSettings.fieldOfView);
	    PlayerPrefs.SetInt("buttonHints", currentSettings.buttonHints);
	    PlayerPrefs.SetInt("gameChat", currentSettings.gameChat);
	    
	    PlayerPrefs.Save();
	    LoadSavedSettings();
    }
*/
    //=-----------------=
    // External Functions
    //=-----------------=
    public void ApplyApplicationSettings()
    {
	    // Graphics
	    PlayerPrefs.SetInt("displayResolution", currentSettings.displayResolution);
	    PlayerPrefs.SetInt("windowMode", currentSettings.windowMode);
	    PlayerPrefs.SetInt("fpsCounter", currentSettings.fpsCounter);
	    PlayerPrefs.SetFloat("fpsLimit", currentSettings.fpsLimit);
	    PlayerPrefs.SetFloat("brightness", currentSettings.brightness);
	    // Quality
	    PlayerPrefs.SetInt("lightingQuality", currentSettings.lightingQuality);
	    PlayerPrefs.SetInt("shadowQuality", currentSettings.shadowQuality);
	    PlayerPrefs.SetInt("textureQuality", currentSettings.textureQuality);
	    PlayerPrefs.SetInt("postProcessingQuality", currentSettings.postProcessingQuality);
	    PlayerPrefs.SetInt("antiAliasing", currentSettings.antiAliasing);
	    PlayerPrefs.SetInt("levelOfDetail", currentSettings.levelOfDetail);
	    PlayerPrefs.SetInt("ambientOcclusion", currentSettings.ambientOcclusion);
	    PlayerPrefs.SetInt("bloom", currentSettings.bloom);
	    PlayerPrefs.SetInt("motionBlur", currentSettings.motionBlur);
	    // Sound
	    PlayerPrefs.SetFloat("master", currentSettings.master);
	    PlayerPrefs.SetFloat("music", currentSettings.music);
	    PlayerPrefs.SetFloat("soundEffects", currentSettings.soundEffects);
	    PlayerPrefs.SetFloat("voiceChat", currentSettings.voiceChat);
	    PlayerPrefs.SetFloat("characterChatter", currentSettings.characterChatter);
	    PlayerPrefs.SetFloat("ambient", currentSettings.ambient);
	    PlayerPrefs.SetFloat("menus", currentSettings.menus);
	    // Gameplay
	    PlayerPrefs.SetFloat("verticalLookSensitivity", currentSettings.verticalLookSensitivity);
	    PlayerPrefs.SetFloat("horizontalLookSensitivity", currentSettings.horizontalLookSensitivity);
	    PlayerPrefs.SetFloat("fieldOfView", currentSettings.fieldOfView);
	    PlayerPrefs.SetInt("buttonHints", currentSettings.buttonHints);
	    PlayerPrefs.SetInt("gameChat", currentSettings.gameChat);
	    
	    PlayerPrefs.Save();
    }
    
    public void UpdateApplicationSetting(string _settingID)
    {
	    // Graphics
	    if (_settingID is "displayResolution" or "all")
	    {
		    Resolution resolution = supportedResolutions[currentSettings.displayResolution];
		    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
	    }
	    
	    if (_settingID is "windowMode" or "all")
	    {
		    Screen.fullScreenMode = currentSettings.windowMode switch
		    {
			    0 => FullScreenMode.Windowed,
			    1 => FullScreenMode.FullScreenWindow,
			    2 => FullScreenMode.ExclusiveFullScreen,
			    _ => Screen.fullScreenMode
		    };
	    }
	    
	    if (_settingID is "fpsCounter" or "all")
	    {
		    if (FindObjectOfType<UI_Debug_FPS>()) FindObjectOfType<UI_Debug_FPS>().ShowFPSCounter(currentSettings.fpsCounter);
	    }
	    
	    if (_settingID is "fpsLimit" or "all")
	    {
		    Application.targetFrameRate = Mathf.RoundToInt(currentSettings.fpsLimit);
	    }
	    
	    if (_settingID is "volume" or "all")
	    {
		    audioMixer.SetFloat("master", currentSettings.master);
		    audioMixer.SetFloat("music", currentSettings.music);
		    audioMixer.SetFloat("soundEffects", currentSettings.soundEffects);
		    audioMixer.SetFloat("voiceChat", currentSettings.voiceChat);
		    audioMixer.SetFloat("characterChatter", currentSettings.characterChatter);
		    audioMixer.SetFloat("ambient", currentSettings.ambient);
		    audioMixer.SetFloat("menus", currentSettings.menus);
	    }

	    if (_settingID is "buttonHints" or "all")
	    {
		    GetComponent<System_ButtonHintManager>().showButtonHints = currentSettings.buttonHints switch
		    {
			    0 => false,
			    1 => true,
			    _ => GetComponent<System_ButtonHintManager>().showButtonHints
		    };
	    }
	}
}
