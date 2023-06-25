//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: Provide functions for the buttons on the error screen for this
//  project
// Applied to: The root of the error menu UI
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Error : MonoBehaviour
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
    private System_SceneLoader sceneLoader;
    private System_MusicManager musicManager;
    [SerializeField] private AudioClip titleMusic;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        sceneLoader = FindObjectOfType<System_SceneLoader>();
        musicManager = FindObjectOfType<System_MusicManager>();
        musicManager.FadeIn(0);
        musicManager.ResetChannels();
        musicManager.SetPrimaryChannel(titleMusic);
    }

    private void Start()
    {
        musicManager.ResetChannels();
    }



    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void ReturnToTitle(string _targetScene)
    {
        musicManager.Fadeout(0);
        if (!sceneLoader) sceneLoader = FindObjectOfType<System_SceneLoader>();
        if (sceneLoader) sceneLoader.LoadScene(_targetScene);
    }
    
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}

