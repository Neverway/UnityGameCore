//=========== Written by Arthur W. Sheldon AKA Lizband_UCC ====================
// [G13]
// Purpose: Allow button Inputs to scroll through and interacting with a menu
// Applied to: The root of a UI menu
//
//=============================================================================

using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_ScrollControl : MonoBehaviour
{
    //=-----------------=
    // Public variables
    //=-----------------=
    [Header("Colors")]
    [Tooltip("The color of the text when it's selected")]
    [SerializeField] private Color selectedTextColor = new Color(1,1,1,1);
    [Tooltip("The color of the text when it's not selected")]
    [SerializeField] private Color unselectedTextColor = new Color(0.5f,0.5f,0.5f,1);
    [Tooltip("The color of the text when it's pressed")]
    [SerializeField] private Color pressedTextColor = new Color(1,1,1,1);
    [Tooltip("The color of the image when it's selected")]
    [SerializeField] private Color selectedImageColor = new Color(0.38f,0.38f,0.38f,0.6f);
    [Tooltip("The color of the image when it's not selected")]
    [SerializeField] private Color unselectedImageColor = new Color(0.15f,0.15f,0.15f,0.75f);
    [Tooltip("The color of the image when it's pressed")]
    [SerializeField] private Color pressedImageColor = new Color(0.1f,0.1f,0.1f,0.6f);
    [Tooltip("How long it takes for the image or text color transition")]
    [SerializeField] private float colorLerpTime = 0.05f;
    
    [Header("Options")]
    [Tooltip("If true, when reaching the end of the list, wrap back around to the other side")]
    [SerializeField] private bool wrapAroundScrolling;
    [Tooltip("If true, the left and right keys are used to navigate the menu instead of the up and down keys")]
    [SerializeField] private bool horizontalScrolling;
    [Tooltip("The selectable options that will be scrolled through")]
    [SerializeField] private MenuOptions[] menuOptions;
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

/*
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
	    indexLimit = menuOptions.Length-1;
	    action = new Input_Actions().Menu;
	    action.Enable();
    }

    private void Update()
    {
	    SelectControl();
	    if (menuOptions.Length == 0) return;
	    IndexControl();
	    SetColorAndText();
    }
    
    
    //=-----------------=
    // Internal Functions
    //=-----------------=
    private IEnumerator RepeatPressDelay()
    {
	    yield return new WaitForSeconds(0.2f);
	    acceptingInput = true;
    }

    private void ScrollEvent()
    {
	    acceptingInput = false;
	    menuOptions[scrollIndex].onHovered.Invoke();
	    StartCoroutine(RepeatPressDelay());
    }
    
    // Control scrolling through the menu and firing onHover events
    private void IndexControl()
    {
	    if (!acceptingInput) return;
			if (!horizontalScrolling && action.MoveUp.IsPressed() || horizontalScrolling && action.MoveLeft.IsPressed())
			{
				if (scrollIndex > 0 && !wrapAroundScrolling) { scrollIndex--; PlayAudio("Scroll"); }
				else if (scrollIndex == 0 && wrapAroundScrolling) { scrollIndex = indexLimit; PlayAudio("Scroll"); }
				ScrollEvent();
			}
			if (!horizontalScrolling && action.MoveDown.IsPressed() || horizontalScrolling && action.MoveRight.IsPressed())
			{
				if (scrollIndex < indexLimit && !wrapAroundScrolling) { scrollIndex++; PlayAudio("Scroll"); }
				else if (scrollIndex == indexLimit && wrapAroundScrolling) { scrollIndex = 0; PlayAudio("Scroll"); }
				ScrollEvent();
			}
    }

    // Set the colors of the text objects based on weather they are selected or not
    private void SetColorAndText()
    {
	    for (int i = 0; i < indexLimit+1; i++)
	    {
		    if (i != scrollIndex)
		    {
			    
			    menuOptions[i].imageObject.color = Color.Lerp(menuOptions[i].imageObject.color, unselectedImageColor, colorLerpTime);
			    menuOptions[i].textObject.color = Color.Lerp(menuOptions[i].textObject.color, unselectedTextColor, colorLerpTime);
			    menuOptions[i].textObject.text = menuOptions[i].textNormal;
		    }
		    else
		    {
			    menuOptions[i].imageObject.color = Color.Lerp(menuOptions[i].imageObject.color, selectedImageColor, colorLerpTime);
			    menuOptions[i].textObject.color = Color.Lerp(menuOptions[i].textObject.color, selectedTextColor, colorLerpTime);
			    menuOptions[i].textObject.text = menuOptions[i].textSelected;
		    }
	    }
    }

    // Handel selecting a menu option or hitting the back button
    private void SelectControl()
    {
	    if (action.Back.WasPressedThisFrame())
	    {
		    onBack.Invoke();
	    }
	    if (menuOptions.Length == 0) return;
	    if (action.Interact.WasPressedThisFrame())
	    {
		    PlayAudio("Select"); 
		    menuOptions[scrollIndex].onSelected.Invoke();
	    }
	    if (action.Interact.IsPressed())
	    {
		    menuOptions[scrollIndex].imageObject.color = Color.Lerp(menuOptions[scrollIndex].imageObject.color, pressedImageColor, colorLerpTime);
		    menuOptions[scrollIndex].textObject.color = Color.Lerp(menuOptions[scrollIndex].textObject.color, pressedTextColor, colorLerpTime);
	    }
	    else if (action.Interact.WasReleasedThisFrame())
	    {
		    menuOptions[scrollIndex].imageObject.color = Color.Lerp(menuOptions[scrollIndex].imageObject.color, selectedImageColor, colorLerpTime);
		    menuOptions[scrollIndex].textObject.color = Color.Lerp(menuOptions[scrollIndex].textObject.color, selectedTextColor, colorLerpTime);
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
			    switch (menuOptions[scrollIndex].selectable)
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
    */
    [Serializable]
    public class MenuOptions
    {
	    
	    [Tooltip("The string to display normally")]
	    public string textNormal;
	    [Tooltip("The string to display when it's index is selected (usually just the above value with an indicator like `>` in front of it)")]
	    public string textSelected;
	    [Tooltip("If true, the select success sound will play and onSelected will be executed")]
	    public bool selectable = true;
	    [Tooltip("The target that the string and color will be applied to (must have a text or TMP text component)")]
	    public TMP_Text textObject;
	    [Tooltip("The target that the string and color will be applied to (must have a text or TMP text component)")]
	    public Image imageObject;
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
		    menuOptions[i].imageObject.color = Color.Lerp(menuOptions[scrollIndex].imageObject.color, unselectedImageColor, colorLerpTime);
		    menuOptions[i].textObject.color = Color.Lerp(menuOptions[scrollIndex].textObject.color, unselectedTextColor, colorLerpTime);
		    menuOptions[i].textObject.text = menuOptions[i].textNormal;
	    }
    }

    public void SetNormalText(int _index, string _text)
    {
	    menuOptions[_index].textNormal = _text;
    }

    public void SetSelectedText(int _index, string _text)
    {
	    menuOptions[_index].textSelected = _text;
    }
}