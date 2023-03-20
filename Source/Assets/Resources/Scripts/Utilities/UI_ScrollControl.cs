//=========== Written by Arthur W. Sheldon AKA Lizband_UCC ====================
// [G13]
// Purpose: Allow button Inputs to scroll through and interacting with a menu
// Applied to: The root of a UI menu
// Editor script: 
// Notes: 
//
//=============================================================================

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_ScrollControl : MonoBehaviour
{
    //=-----------------=
    // Public variables
    //=-----------------=
    [Header("Colors")]
    [Tooltip("The color of the sprite when it's selected")]
    [SerializeField] private Color selectedColor = new Color(1,1,1,1);
    [Tooltip("The color of the sprite when it's not selected")]
    [SerializeField] private Color unselectedColor = new Color(0.25f,0.25f,0.25f,1);
    
    [Header("Options")]
    [Tooltip("If true, when reaching the end of the list, wrap back around to the other side")]
    [SerializeField] private bool wrapAroundScrolling;
    [Tooltip("If true, the left and right keys are used to navigate the menu instead of the up and down keys")]
    [SerializeField] private bool horizontalScrolling;
    [Tooltip("If true, looks for the TMP pro component on the textOptions instead of the standard text component")]
    [SerializeField] private bool usingTextMeshPro = true;
    [Tooltip("The selectable options that will be scrolled through")]
    [SerializeField] private TextOptions[] textOption;
    [Tooltip("Executes when the back key is pressed and the menu is active")]
    [SerializeField] private UnityEvent onBack;
    
    [Header("Sound Effects")]
    [Tooltip("The sound that's played when scrolling through the menu")]
    [SerializeField] private AudioSource scroll;
    [Tooltip("The sound that's played when selecting an enabled menu option")]
    [SerializeField] private AudioSource selectSuccess;
    [Tooltip("The sound that's played when selecting a disabled menu option")]
    [SerializeField] private AudioSource selectDenied;


    //=-----------------=
    // Private variables
    //=-----------------=
    private int scrollIndex; // The current position in the menu
    private int indexLimit; // The length of the menu array
    private bool acceptingInput = true; // Used for the keypress delay (Holding the button scrolls down, waits, & repeats)


    //=-----------------=
    // Reference variables
    //=-----------------=
    private Input_Actions.MenuActions action;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void OnDisable()
    {
	    StopCoroutine(RepeatPressDelay());
	    acceptingInput = true;
    }

    private void Start()
    {
	    indexLimit = textOption.Length-1;
	    action = new Input_Actions().Menu;
	    action.Enable();
    }

    private IEnumerator RepeatPressDelay()
    {
	    yield return new WaitForSeconds(0.2f);
	    acceptingInput = true;
    }

    private void Update()
    {
	    IndexControl();
	    SetColorAndText();
	    SelectControl();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    // Control scrolling through the menu and firing onHover events
    private void IndexControl()
    {
	    // Scroll up and down through the menu
	    if (!horizontalScrolling)
		{
			if (action.MoveUp.IsPressed())
			{
				if (!acceptingInput) { return; }
				acceptingInput = false;
				if (scrollIndex > 0 && !wrapAroundScrolling) { scrollIndex--; PlayAudio("Scroll"); }
				else if (scrollIndex == 0 && wrapAroundScrolling) { scrollIndex = indexLimit; PlayAudio("Scroll"); }
				textOption[scrollIndex].onHovered.Invoke();
				StartCoroutine(RepeatPressDelay());
			}
			else if (action.MoveDown.IsPressed())
			{
				if (!acceptingInput) { return; }
				acceptingInput = false;
				if (scrollIndex < indexLimit && !wrapAroundScrolling) { scrollIndex++; PlayAudio("Scroll"); }
				else if (scrollIndex == indexLimit && wrapAroundScrolling) { scrollIndex = 0; PlayAudio("Scroll"); }
				textOption[scrollIndex].onHovered.Invoke();
				StartCoroutine(RepeatPressDelay());
			}
		}
	    
	    // Scroll left and right through the menu
		else
		{
			if (action.MoveLeft.IsPressed())
			{
				if (!acceptingInput) { return; }
				acceptingInput = false;
				if (scrollIndex > 0 && !wrapAroundScrolling) { scrollIndex--; PlayAudio("Scroll"); }
				else if (scrollIndex == 0 && wrapAroundScrolling) { scrollIndex = indexLimit; PlayAudio("Scroll"); }
				textOption[scrollIndex].onHovered.Invoke();
				StartCoroutine(RepeatPressDelay());
			}
			else if (action.MoveRight.IsPressed())
			{
				if (!acceptingInput) { return; }
				acceptingInput = false;
				if (scrollIndex < indexLimit && !wrapAroundScrolling) { scrollIndex++; PlayAudio("Scroll"); }
				else if (scrollIndex == indexLimit && wrapAroundScrolling) { scrollIndex = 0; PlayAudio("Scroll"); }
				textOption[scrollIndex].onHovered.Invoke();
				StartCoroutine(RepeatPressDelay());
			}
		}
    }

    // Set the colors of the text objects based on weather they are selected or not
    private void SetColorAndText()
    {
	    for (int i = 0; i < indexLimit+1; i++)
	    {
		    if (i != scrollIndex)
		    {
			    if (!usingTextMeshPro)
			    {
				    textOption[i].textObject.GetComponent<Text>().color = unselectedColor;
				    textOption[i].textObject.GetComponent<Text>().text = textOption[i].textNormal;
			    }
			    else
			    {
				    textOption[i].textObject.GetComponent<TMP_Text>().color = unselectedColor;
				    textOption[i].textObject.GetComponent<TMP_Text>().text = textOption[i].textNormal;
			    }
		    }
		    else
		    {
			    if (!usingTextMeshPro)
			    {
				    textOption[i].textObject.gameObject.GetComponent<Text>().color = selectedColor;
				    textOption[i].textObject.GetComponent<Text>().text = textOption[i].textSelected;
			    }
			    else
			    {
				    textOption[i].textObject.gameObject.GetComponent<TMP_Text>().color = selectedColor;
				    textOption[i].textObject.GetComponent<TMP_Text>().text = textOption[i].textSelected;
			    }
		    }
	    }
    }

    // Handel selecting a menu option or hitting the back button
    private void SelectControl()
    {
	    if (action.Interact.WasPressedThisFrame())
	    {
		    PlayAudio("Select"); 
		    textOption[scrollIndex].onSelected.Invoke();
	    }
	    else if (action.Back.WasPressedThisFrame())
	    {
		    onBack.Invoke();
	    }
    }

    // Play sound effects for different menu actions
    private void PlayAudio(string audioSource)
    {
	    switch (audioSource)
	    {
		    case "Scroll":
		    {
			    if (scroll != null) { scroll.Play(); }
			    return;
		    }
		    case "Select":
		    {
			    switch (textOption[scrollIndex].selectable)
			    {
				    case true when selectSuccess:
					    selectSuccess.Play();
					    break;
				    case false when selectDenied:
					    selectDenied.Play();
					    break;
			    }
			    return;
		    }
	    }
    }
    
    [Serializable]
    public class TextOptions
    {
	    
	    [Tooltip("The string to display normally")]
	    public string textNormal;
	    [Tooltip("The string to display when it's index is selected (usually just the above value with an indicator like `>` in front of it)")]
	    public string textSelected;
	    [Tooltip("If true, the select success sound will play and onSelected will be executed")]
	    public bool selectable = true;
	    [Tooltip("The target that the string and color will be applied to (must have a text or TMP text component)")]
	    public GameObject textObject;
	    [Tooltip("Executes when the current index becomes active")]
	    public UnityEvent onHovered;
	    [Tooltip("Executes if the menu selection key is pressed and the index is selectable")]
	    public UnityEvent onSelected;
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
    public void SetScrollIndex(int _scrollIndex)
    {
	    scrollIndex = _scrollIndex;
    }
    
    public int GetScrollIndex()
    {
	    return scrollIndex;
    }
    
    public void SetToDeselected()
    {
	    
	    for (int i = 0; i < indexLimit+1; i++)
	    {
		    if (!usingTextMeshPro)
		    {
			    textOption[i].textObject.GetComponent<Text>().color = unselectedColor;
			    textOption[i].textObject.GetComponent<Text>().text = textOption[i].textNormal;
		    }
		    else
		    {
			    textOption[i].textObject.GetComponent<TMP_Text>().color = unselectedColor;
			    textOption[i].textObject.GetComponent<TMP_Text>().text = textOption[i].textNormal;
		    }
	    }
    }

    public void SetNormalText(int _index, string _text)
    {
	    textOption[_index].textNormal = _text;
    }

    public void SetSelectedText(int _index, string _text)
    {
	    textOption[_index].textSelected = _text;
    }
}