//======== Neverway 2022 Project Script | Written by Arthur Aka Liz ===========
// 
// Purpose: ....
// Applied to: The root of the textbox menu UI
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Textbox : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    public bool textboxOpen;
    public float textPrintSpeed;


    //=-----------------=
    // Private Variables
    //=-----------------=
    private List<Textbox_Data> textboxData;
    private int currentLineIndex;
    private bool onCooldown;
    private string textCurrent;
    private bool printing;


    //=-----------------=
    // Reference Variables
    //=-----------------=
    private Input_Actions.Player2DActions action;
    private System_MenuManager menuManager;
    [SerializeField] private Image portraitImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text monologueText;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Awake()
    {
	    action = new Input_Actions().Player2D;
	    action.Enable();
	    menuManager = FindObjectOfType<System_MenuManager>();
    }

    private void Update()
    {
	    monologueText.text = textCurrent;
	    dialogueText.text = textCurrent;
	    if (action.Interact.WasPressedThisFrame() && textboxOpen && !printing)
	    {
			NextLine();
	    }
    }

    private IEnumerator Cooldown()
    {
	    yield return new WaitForSeconds(0.25f);
	    onCooldown = false;
    }

    IEnumerator TypeText()
    {
	    printing = true;
	    
	    for (int i = 0; i < textboxData[currentLineIndex].textLine.Length + 1; i++)
	    {
		    textCurrent = textboxData[currentLineIndex].textLine.Substring(0, i);
		    yield return new WaitForSeconds(textPrintSpeed);
	    }

	    printing = false;
    }

    //=-----------------=
    // Internal Functions
    //=-----------------=
    private bool IsMonologueMode()
    {
	    return textboxData[currentLineIndex].portrait == null;
    }

    private void SetDisplayMode()
    {
	    if (IsMonologueMode())
	    {
		    portraitImage.GameObject().SetActive(false);
		    nameText.GameObject().SetActive(false);
		    dialogueText.GameObject().SetActive(false);
		    monologueText.GameObject().SetActive(true);
	    }
	    else
	    {
		    portraitImage.GameObject().SetActive(true);
		    nameText.GameObject().SetActive(true);
		    dialogueText.GameObject().SetActive(true);
		    monologueText.GameObject().SetActive(false);
	    }
    }
    
    private void AssignCurrentLineData()
    {
	    if (IsMonologueMode())
	    {
		    StartCoroutine(TypeText());
	    }
	    else
	    {
		    portraitImage.sprite = textboxData[currentLineIndex].portrait;
		    nameText.text = textboxData[currentLineIndex].name;
		    StartCoroutine(TypeText());
	    }
    }

    private void OpenTextbox()
    {
	    if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
	    menuManager.menuOpen = true;
	    onCooldown = true;
	    textboxOpen = true;
	    // Enable the textbox container
	    transform.GetChild(0).gameObject.SetActive(true);
	    // Reset the currentLineIndex
	    currentLineIndex = 0;
	    // Enable mono/dia objects
	    SetDisplayMode();
	    // Assign mono/dia data for current line
	    AssignCurrentLineData();
    }
    
    private void CloseTextbox()
    {
	    if (!menuManager) menuManager = FindObjectOfType<System_MenuManager>();
	    menuManager.menuOpen = false;
	    StartCoroutine(Cooldown());
	    textboxOpen = false;
	    // Disable the textbox container
	    transform.GetChild(0).gameObject.SetActive(false);
	    // Disable mono/dia objects
	    portraitImage.GameObject().SetActive(false);
	    nameText.GameObject().SetActive(false);
	    dialogueText.GameObject().SetActive(false);
	    monologueText.GameObject().SetActive(false);
    }


    //=-----------------=
    // External Functions
    //=-----------------=
    public void PrintText(List<Textbox_Data> _textboxData)
    {
	    if (onCooldown) return;
	    textboxData = _textboxData;
	    OpenTextbox();
    }

    private void NextLine()
    {
	    // if finished printing current line
	    // Close textbox if on last line
	    if (textboxData.Count == currentLineIndex + 1)
	    {
		    CloseTextbox();
		    return;
	    }
	    // Increment the currentLineIndex
	    currentLineIndex++;
	    // Enable mono/dia objects
	    SetDisplayMode();
	    // Assign mono/dia data for current line
	    AssignCurrentLineData();
    }
}