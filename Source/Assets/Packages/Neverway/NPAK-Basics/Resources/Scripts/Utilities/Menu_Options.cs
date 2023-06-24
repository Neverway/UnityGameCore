//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Pass UI events to modify the System_ApplicationSettings values
// Applied to: The root of the options menu
//
//=============================================================================

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Options : MonoBehaviour
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
    private UI_Text_FPS fpsCounterElement;
    [Header("Graphics")]
    [SerializeField] private TMP_Dropdown displayResolution;
    [SerializeField] private TMP_Dropdown windowMode;
    [SerializeField] private TMP_Dropdown fpsCounter;
    [SerializeField] private Slider fpsLimit;
    [SerializeField] private Slider brightness;
    [Header("Quality")]
    [SerializeField] private TMP_Dropdown lightingQuality;
    [SerializeField] private TMP_Dropdown shadowQuality;
    [SerializeField] private TMP_Dropdown textureQuality;
    [SerializeField] private TMP_Dropdown postProcessingQuality;
    [SerializeField] private TMP_Dropdown antiAliasing;
    [SerializeField] private TMP_Dropdown levelOfDetail;
    [SerializeField] private TMP_Dropdown ambientOcclusion;
    [SerializeField] private TMP_Dropdown bloom;
    [SerializeField] private TMP_Dropdown motionBlur;
    [Header("Sound")]
    [SerializeField] private Slider master;
    [SerializeField] private Slider music;
    [SerializeField] private Slider soundEffects;
    [SerializeField] private Slider voiceChat;
    [SerializeField] private Slider characterChatter;
    [SerializeField] private Slider ambient;
    [SerializeField] private Slider menus;
    [Header("Gameplay")] 
    [SerializeField] private Slider verticalLookSensitivity;
    [SerializeField] private Slider horizontalLookSensitivity;
    [SerializeField] private Slider fieldOfView;
    [SerializeField] private TMP_Dropdown buttonHints;
    [SerializeField] private TMP_Dropdown gameChat;
    [SerializeField] private TMP_Dropdown graphicContent;
    [SerializeField] private TMP_Dropdown splitscreenOrientation;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        applicationSettings = FindObjectOfType<System_ApplicationSettings>();
        if (displayResolution) GetSupportedDisplayResolutions();
        GetCurrentSettings();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void GetCurrentSettings()
    {
        if (!applicationSettings)
        {
            Debug.LogWarning("An options menu is trying to access System_ApplicationSettings, but it was not found. The options menu will not function correctly without it!");
            return;
        }
        // Graphics
        if (displayResolution) displayResolution.value = applicationSettings.currentSettings.displayResolution;
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
            if (supportedResolutions[i].width == Screen.currentResolution.width && supportedResolutions[i].height == Screen.currentResolution.height) currentResolutionIndex = i;
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

    public void SetShadowQuality(int _value)
    {
        applicationSettings.currentSettings.shadowQuality = _value;
        applicationSettings.UpdateApplicationSetting("shadowQuality");
    }

    public void SetAntiAliasing(int _value)
    {
        applicationSettings.currentSettings.antiAliasing = _value;
        applicationSettings.UpdateApplicationSetting("antiAliasing");
    }

    public void SetLevelOfDetail(int _value)
    {
        applicationSettings.currentSettings.levelOfDetail = _value;
        applicationSettings.UpdateApplicationSetting("levelOfDetail");
    }

    public void SetAmbientOcclusion(int _value)
    {
        applicationSettings.currentSettings.ambientOcclusion = _value;
        applicationSettings.UpdateApplicationSetting("ambientOcclusion");
    }

    public void SetBloom(int _value)
    {
        applicationSettings.currentSettings.bloom = _value;
        applicationSettings.UpdateApplicationSetting("bloom");
    }

    public void SetMotionBlur(int _value)
    {
        applicationSettings.currentSettings.motionBlur = _value;
        applicationSettings.UpdateApplicationSetting("motionBlur");
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

