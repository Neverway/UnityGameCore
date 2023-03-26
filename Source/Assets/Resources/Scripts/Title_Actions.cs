//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes: 
//
//=============================================================================

using UnityEngine;

public class Title_Actions : MonoBehaviour
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
    private void Start()
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
        if (sceneLoader) sceneLoader.LoadScene(_targetScene);
    }
    public void QuitToDesktop()
    {
        Application.Quit();
    }
}

