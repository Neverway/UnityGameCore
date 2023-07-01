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

public class Entity_Look3D : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private float xSensitivity=50;
    [SerializeField] private float ySensitivity=100;
    [SerializeField] private float multiplier = 0.025f;
    public float xInput;
    public float yInput;
    public float xInputAlternate;
    public float yInputAlternate;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private float xRotation;
    private float yRotation;


    //=-----------------=
    // Reference Variables
    //=-----------------=
    public Camera entityCamera;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        entityCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        yRotation += (xInput + xInputAlternate) * xSensitivity * multiplier;
        xRotation -= (yInput + yInputAlternate) * ySensitivity * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        
        entityCamera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.rotation = Quaternion.Euler(0, yRotation,0);
    }


    //=-----------------=
    // Internal Functions
    //=-----------------=


    //=-----------------=
    // External Functions
    //=-----------------=
}

