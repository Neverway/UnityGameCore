//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: Keep this object when changing scenes. Destroy the new instance
//  if the object exists in the next scene.
//
//=============================================================================

using UnityEngine;

public class System_PersistentSingleton : MonoBehaviour
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
    private static GameObject instance;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = gameObject;
        DontDestroyOnLoad(instance);
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

