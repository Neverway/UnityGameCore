//========== Neverway 2023 Project Script | Written by Unknown Dev ============
// 
// Type: 
// Purpose: 
// Applied to: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Mirror : MonoBehaviour
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
    private Transform targetViewer;
    [SerializeField] private Transform mirror;


    //=-----------------=
    // Mono Functions
    //=-----------------=


    //=-----------------=
    // Internal Functions
    //=-----------------=
    private void Update()
    {
        targetViewer = Camera.current.gameObject.transform;
        Vector3 localViewer = mirror.InverseTransformPoint(targetViewer.position);
        transform.position = mirror.TransformPoint(new Vector3(localViewer.x, localViewer.y, -localViewer.z));
        Vector3 lookAtMirror = mirror.TransformPoint(new Vector3(-localViewer.x, localViewer.y, localViewer.z));
        transform.LookAt(lookAtMirror);
    }


    //=-----------------=
    // External Functions
    //=-----------------=
}

