//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

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


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        sceneLoader = FindObjectOfType<System_SceneLoader>();
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void StartGame(string _targetScene)
    {
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

