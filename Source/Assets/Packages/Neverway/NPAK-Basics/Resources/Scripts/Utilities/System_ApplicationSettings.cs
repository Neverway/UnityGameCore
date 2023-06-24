//======== Neverway 2023 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Utility
// Purpose: Handle the functions for changing application settings that are
//    called by Menu_Options
// Applied to: The persistent system manager
//
//=============================================================================

using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;

public class System_ApplicationSettings : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public AudioMixer audioMixer;
    public AppSettings defaultSettings;
    public AppSettings currentSettings;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private Resolution[] supportedResolutions;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    [SerializeField] private PostProcessProfile overlayProfile;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
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
		    if (FindObjectOfType<UI_Text_FPS>()) FindObjectOfType<UI_Text_FPS>().ShowFPSCounter(currentSettings.fpsCounter);
	    }
	    
	    if (_settingID is "fpsLimit" or "all")
	    {
		    Application.targetFrameRate = Mathf.RoundToInt(currentSettings.fpsLimit);
	    }
	    
	    if (_settingID is "brightness" or "all")
	    {
		    var screenBrightness = (currentSettings.brightness/20)-5;
		    overlayProfile.GetSetting<ColorGrading>().postExposure.value = screenBrightness;
	    }
	    
	    if (_settingID is "shadowQuality" or "all")
	    {
		    switch (currentSettings.shadowQuality)
		    {
			    case 0:
				    QualitySettings.shadowResolution = (ShadowResolution)0;
				    QualitySettings.shadows = (ShadowQuality)0;
				    QualitySettings.shadowDistance = 10;
				    break;
			    case 1:
				    QualitySettings.shadowResolution = (ShadowResolution)1;
				    QualitySettings.shadows = (ShadowQuality)1;
				    QualitySettings.shadowDistance = 20;
				    break;
			    case 2:
				    QualitySettings.shadowResolution = (ShadowResolution)2;
				    QualitySettings.shadows = (ShadowQuality)2;
				    QualitySettings.shadowDistance = 20;
				    break;
			    case 3:
				    QualitySettings.shadowResolution = (ShadowResolution)3;
				    QualitySettings.shadows = (ShadowQuality)3;
				    QualitySettings.shadowDistance = 40;
				    break;
			    case 4:
				    QualitySettings.shadowResolution = (ShadowResolution)3;
				    QualitySettings.shadows = (ShadowQuality)3;
				    QualitySettings.shadowDistance = 150;
				    break;
		    }
	    }
	    
	    if (_settingID is "antiAliasing" or "all")
	    {
		    // 0=NoMSAA, 1=2x, 2=4x, 3=8x
		    switch (currentSettings.antiAliasing)
		    {
			    case 0:
				    QualitySettings.antiAliasing = 0;
				    break;
			    case 1:
				    QualitySettings.antiAliasing = 2;
				    break;
			    case 2:
				    QualitySettings.antiAliasing = 4;
				    break;
			    case 3:
				    QualitySettings.antiAliasing = 8;
				    break;
		    }
	    }
	    
	    if (_settingID is "levelOfDetail" or "all")
	    {
		    QualitySettings.SetLODSettings(QualitySettings.lodBias, currentSettings.levelOfDetail);
	    }
	    
	    if (_settingID is "ambientOcclusion" or "all")
	    {
		    switch (currentSettings.ambientOcclusion)
		    {
			    case 0:
				    overlayProfile.GetSetting<AmbientOcclusion>().intensity.value = 0f;
				    break;
			    case 1:
				    overlayProfile.GetSetting<AmbientOcclusion>().intensity.value = 25f;
				    break;
			    case 2:
				    overlayProfile.GetSetting<AmbientOcclusion>().intensity.value = 50f;
				    break;
			    case 3:
				    overlayProfile.GetSetting<AmbientOcclusion>().intensity.value = 100f;
				    break;
		    }
	    }
	    
	    if (_settingID is "bloom" or "all")
	    {
			if (!overlayProfile.GetSetting<Bloom>()) return;
			switch (currentSettings.bloom)
			{
				case 0:
					overlayProfile.GetSetting<Bloom>().intensity.value = 0f;
					overlayProfile.GetSetting<Bloom>().softKnee.value = 0f;
					overlayProfile.GetSetting<Bloom>().diffusion.value = 0f;
					break;
				case 1:
					overlayProfile.GetSetting<Bloom>().intensity.value = 3f;
					overlayProfile.GetSetting<Bloom>().softKnee.value = 0.5f;
					overlayProfile.GetSetting<Bloom>().diffusion.value = 5f;
					break;
				case 2:
					overlayProfile.GetSetting<Bloom>().intensity.value = 8f;
					overlayProfile.GetSetting<Bloom>().softKnee.value = 0.5f;
					overlayProfile.GetSetting<Bloom>().diffusion.value = 7f;
					break;
				case 3:
					overlayProfile.GetSetting<Bloom>().intensity.value = 25f;
					overlayProfile.GetSetting<Bloom>().softKnee.value = 0.38f;
					overlayProfile.GetSetting<Bloom>().diffusion.value = 3.3f;
					break;
			}
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

