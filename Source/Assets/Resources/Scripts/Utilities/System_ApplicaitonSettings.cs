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
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
	
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
}

