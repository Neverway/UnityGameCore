//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: When a player activates the trigger, fade to the specified track
//     from whatever is currently playing
// Applied to: 
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Music : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [SerializeField] private bool disableAfterUse;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private bool inTrigger;
    private bool activated;


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private System_MusicManager musicManager;
    private readonly Entity_Referencer entityReferencer = new Entity_Referencer();
    [SerializeField] public AudioClip targetTrack;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    musicManager = FindObjectOfType<System_MusicManager>();
    }

    private void Update()
    {
	    if (inTrigger && !activated && musicManager)
	    {
		    musicManager.SetSecondaryChannel(targetTrack);
		    musicManager.CrossFadeTracks();
		    if (disableAfterUse) Destroy(gameObject, 0.2f);
		    activated = true;
	    }

	    if (!inTrigger) activated = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if (!musicManager) musicManager = FindObjectOfType<System_MusicManager>();
	    if (!targetEnt || !musicManager) return;
	    if (targetEnt == entityReferencer.GetPlayerEntity()) inTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if (!musicManager) musicManager = FindObjectOfType<System_MusicManager>();
	    if (!targetEnt || !musicManager) return;
	    if (targetEnt == entityReferencer.GetPlayerEntity()) inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
	    if (!other.CompareTag("Entity")) return;
	    var targetEnt = other.gameObject.transform.parent.GetComponent<Entity>();
	    if (!musicManager) musicManager = FindObjectOfType<System_MusicManager>();
	    if (!targetEnt || !musicManager) return;
	    if (targetEnt == entityReferencer.GetPlayerEntity()) inTrigger = false;
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=


    //=-----------------=
    // External Functions
    //=-----------------=
}

