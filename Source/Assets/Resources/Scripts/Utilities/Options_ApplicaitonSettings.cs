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
using UnityEngine.UI;

public class Options_ApplicaitonSettings : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Resolution[] supportedResolutions;
    private string targetVolumeChannel;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_ApplicationSettings applicationSettings;
    private UI_Debug_FPS fpsCounterElement;
    [Header("Graphics")]
    public TMP_Dropdown displayResolution;
    public TMP_Dropdown windowMode;
    public TMP_Dropdown fpsCounter;
    public Slider fpsLimit;
    public Slider brightness;
    [Header("Quality")]
    public TMP_Dropdown lightingQuality;
    public TMP_Dropdown shadowQuality;
    public TMP_Dropdown textureQuality;
    public TMP_Dropdown postProcessingQuality;
    public TMP_Dropdown antiAliasing;
    public TMP_Dropdown levelOfDetail;
    public TMP_Dropdown ambientOcclusion;
    public TMP_Dropdown bloom;
    public TMP_Dropdown motionBlur;
    [Header("Sound")]
    public Slider master;
    public Slider music;
    public Slider soundEffects;
    public Slider voiceChat;
    public Slider characterChatter;
    public Slider ambient;
    public Slider menus;
    [Header("Gameplay")] 
    public Slider verticalLookSensitivity;
    public Slider horizontalLookSensitivity;
    public Slider fieldOfView;
    public TMP_Dropdown buttonHints;
    public TMP_Dropdown gameChat;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        applicationSettings = FindObjectOfType<System_ApplicationSettings>();
        if (displayResolution) GetSupportedDisplayResolutions();
        GetCurrentSettings();
    }

    private void Update()
    {
	
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void GetCurrentSettings()
    {
        // Graphics
        if (displayResolution)
            print("3"); displayResolution.value = applicationSettings.currentSettings.displayResolution;
        if (windowMode) windowMode.value = applicationSettings.currentSettings.windowMode;
        if (fpsCounter) fpsCounter.value = applicationSettings.currentSettings.fpsCounter;
        if (fpsLimit) fpsLimit.value = applicationSettings.currentSettings.fpsLimit;
        if (brightness) brightness.value = applicationSettings.currentSettings.brightness;
        // Quality
        if (lightingQuality) lightingQuality.value = applicationSettings.currentSettings.lightingQuality;
        if (shadowQuality) shadowQuality.value = applicationSettings.currentSettings.shadowQuality;
        if (textureQuality) textureQuality.value = applicationSettings.currentSettings.textureQuality;
        if (postProcessingQuality) postProcessingQuality.value = applicationSettings.currentSettings.postProcessingQuality;
        if (antiAliasing) antiAliasing.value = applicationSettings.currentSettings.antiAliasing;
        if (levelOfDetail) levelOfDetail.value = applicationSettings.currentSettings.levelOfDetail;
        if (ambientOcclusion) ambientOcclusion.value = applicationSettings.currentSettings.ambientOcclusion;
        if (bloom) bloom.value = applicationSettings.currentSettings.bloom;
        if (motionBlur) motionBlur.value = applicationSettings.currentSettings.motionBlur;
        // Sound
        if (master) master.value = applicationSettings.currentSettings.master;
        if (music) music.value = applicationSettings.currentSettings.music;
        if (soundEffects) soundEffects.value = applicationSettings.currentSettings.soundEffects;
        if (voiceChat) voiceChat.value = applicationSettings.currentSettings.voiceChat;
        if (characterChatter) characterChatter.value = applicationSettings.currentSettings.characterChatter;
        if (ambient) ambient.value = applicationSettings.currentSettings.ambient;
        if (menus) menus.value = applicationSettings.currentSettings.menus;
        // Gameplay
        if (verticalLookSensitivity) verticalLookSensitivity.value = applicationSettings.currentSettings.verticalLookSensitivity;
        if (horizontalLookSensitivity) horizontalLookSensitivity.value = applicationSettings.currentSettings.horizontalLookSensitivity;
        if (fieldOfView) fieldOfView.value = applicationSettings.currentSettings.fieldOfView;
        if (buttonHints) buttonHints.value = applicationSettings.currentSettings.buttonHints;
        if (gameChat) gameChat.value = applicationSettings.currentSettings.gameChat;
    }

    private void GetSupportedDisplayResolutions()
    {
        supportedResolutions = Screen.resolutions;
        displayResolution.ClearOptions();
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
        displayResolution.AddOptions(options);
        displayResolution.value = currentResolutionIndex;
        displayResolution.RefreshShownValue();
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void ApplyApplicationSettings()
    {
        applicationSettings.ApplyApplicationSettings();
    }

    public void SetDisplayResolution(int _resolutionIndex)
    {
        applicationSettings.currentSettings.displayResolution = _resolutionIndex;
        applicationSettings.UpdateApplicationSetting("displayResolution");
    }

    public void SetWindowMode(int _mode)
    {
        applicationSettings.currentSettings.windowMode = _mode;
        applicationSettings.UpdateApplicationSetting("windowMode");
    }

    public void SetFpsCounter(int _value)
    {
        applicationSettings.currentSettings.fpsCounter = _value;
        applicationSettings.UpdateApplicationSetting("fpsCounter");
    }

    public void SetFpsLimit(float _limit)
    {
        applicationSettings.currentSettings.fpsLimit = _limit;
        applicationSettings.UpdateApplicationSetting("fpsLimit");
    }

    public void SetBrightness(float _level)
    {
        applicationSettings.currentSettings.brightness = _level;
        applicationSettings.UpdateApplicationSetting("brightness");
    }
    
    public void SetVolumeChannelTarget(string _channel)
    {
        targetVolumeChannel = _channel;
    }
    
    public void SetVolume(float _level)
    {
        switch (targetVolumeChannel)
        {
            case "master":
                applicationSettings.currentSettings.master = _level;
                break;
            case "music":
                applicationSettings.currentSettings.music = _level;
                break;
            case "soundEffects":
                applicationSettings.currentSettings.soundEffects = _level;
                break;
            case "voiceChat":
                applicationSettings.currentSettings.voiceChat = _level;
                break;
            case "characterChatter":
                applicationSettings.currentSettings.characterChatter = _level;
                break;
            case "ambient":
                applicationSettings.currentSettings.ambient = _level;
                break;
            case "menus":
                applicationSettings.currentSettings.menus = _level;
                break;
        }
        applicationSettings.UpdateApplicationSetting("volume");
    }

    public void SetButtonHints(int _value)
    {
        applicationSettings.currentSettings.buttonHints = _value;
        applicationSettings.UpdateApplicationSetting("buttonHints");
    }
}

