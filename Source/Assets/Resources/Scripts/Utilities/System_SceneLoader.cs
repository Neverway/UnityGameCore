//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Asynchronously unload the current scene, and load a targetScene.
//	Show a loading screen while the process is active.
//
//=============================================================================

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class System_SceneLoader : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private float delayBeforeSceneChange = 0.25f;
    [SerializeField] private float minRequiredLoadTime = 2f;
    [SerializeField] private string loadingScreenSceneID = "Loading";


    //=-----------------=
    // Private Variables
    //=-----------------=
    private string targetSceneID;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Image loadingBar;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private IEnumerator Load()
    {
	    yield return new WaitForSeconds(delayBeforeSceneChange);
	    SceneManager.LoadScene(loadingScreenSceneID);
	    
	    // The following should execute on the loading screen scene
	    var loadingBarObject = GameObject.FindWithTag("Sys_LoadingBar");
	    if (loadingBarObject) loadingBar = loadingBarObject.GetComponent<Image>();
	    
	    yield return new WaitForSeconds(minRequiredLoadTime);
	    StartCoroutine(LoadAsyncOperation());
    }

    private IEnumerator LoadAsyncOperation()
    {
	    // Create an async operation (Will automatically switch to target scene once it's finished loading)
	    var targetLevel = SceneManager.LoadSceneAsync(targetSceneID);
	    
	    while (targetLevel.progress < 1)
	    {
		    // Set loading bar to reflect async progress
		    if (loadingBar) loadingBar.fillAmount = targetLevel.progress;
		    yield return new WaitForEndOfFrame();
	    }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void LoadScene(string _targetSceneID)
    {
	    targetSceneID = _targetSceneID;
	    StartCoroutine(Load());
    }
}

