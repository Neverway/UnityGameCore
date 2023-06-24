//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Type: Project Utility
// Purpose: Provide functions for the buttons on the title screen for this
//  project
// Applied to: The root of the title menu UI
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Title : MonoBehaviour
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
    [SerializeField] private GameObject[] targetObjects;
    public Animator animator;


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
        animator.speed = 0;
    }

    private void Start()
    {
        musicManager.ResetChannels();
        StartCoroutine(OpeningSplash());
    }

    private IEnumerator OpeningSplash()
    {
        yield return new WaitForSeconds(10.2f);
        foreach (GameObject _object in targetObjects)
        {
            _object.SetActive(true);
        }
        animator.speed = 1;
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void StartGame(string _targetScene)
    {
        musicManager.Fadeout(0);
        if (!sceneLoader) sceneLoader = FindObjectOfType<System_SceneLoader>();
        if (sceneLoader) sceneLoader.LoadScene(_targetScene);
    }
    
    public void StartNetworkGame(string _targetScene)
    {
        if (!sceneLoader) sceneLoader = FindObjectOfType<System_SceneLoader>();
        if (sceneLoader) sceneLoader.NetworkLoadScene(_targetScene);
    }
    
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}

