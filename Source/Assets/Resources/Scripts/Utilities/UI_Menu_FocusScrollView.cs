//========== Neverway 2022 Project Script | Written by Unknown Dev ============
// 
// Purpose: 
// Applied to: 
// Editor script: 
// Notes:
//
//=============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class UI_Menu_FocusScrollView : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Tooltip("The selectable ui elements and their corresponding target that should be autofocused to")]
    public FocusableElement[] focusableElements;
    [SerializeField] private bool useContentChildrenAsFocusableElements;
    


    //=-----------------=
    // Private Variables
    //=-----------------=
    private GameObject selectedUIObject;
    private GameObject previouslySelectedUIObject;
    
    
    //=-----------------=
    // Reference Variables
    //=-----------------=
    private ScrollRect scrollRect;
    [SerializeField] private RectTransform contentWindow;


    //=-----------------=
    // Mono Functions
    //=-----------------=
    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        if (!useContentChildrenAsFocusableElements) return;
        for (int i = 0; i < contentWindow.childCount; i++)
        {
            Array.Resize(ref focusableElements, contentWindow.childCount);
            if (focusableElements.Length != contentWindow.childCount) return;
            if (focusableElements[i].selectableElement) 
                focusableElements[i].selectableElement = contentWindow.GetChild(i).gameObject;
            if (focusableElements[i].focusTarget) 
                focusableElements[i].focusTarget = contentWindow.GetChild(i).GetComponent<RectTransform>();
        }
    }

    private void Update()
    {
        selectedUIObject = EventSystem.current.currentSelectedGameObject;
        if (selectedUIObject == null) return;
        if (selectedUIObject != previouslySelectedUIObject)
        {
            print("PING!");
        }
        UpdateFocus();
    }
    
    //=-----------------=
    // Internal Functions
    //=-----------------
    [Serializable]
    public class FocusableElement
    {
        public GameObject selectableElement;
        public RectTransform focusTarget;
        public float offset;
    }
    
    // Wouldn't be able to have figured this out on my own! Thanks (stack overflow user) maraaaaaaaa! 
    private void SnapTo(RectTransform target, float _offset)
    {
        //if (scrollRect.verticalNormalizedPosition >= 1 || scrollRect.verticalNormalizedPosition <= 0) return;
        var pos = (contentWindow.rect.height + target.localPosition.y + _offset) / contentWindow.rect.height;
        // 1152 / 2
        print(pos);
        scrollRect.verticalNormalizedPosition = pos;
    }
    
    private void UpdateFocus()
    {
        foreach (var _element in focusableElements)
        {
            if (focusableElements.Length == 0 || !_element.selectableElement || !_element.focusTarget) return;
            if (selectedUIObject == _element.selectableElement)
            {
                SnapTo(_element.focusTarget , _element.offset);
                previouslySelectedUIObject = EventSystem.current.currentSelectedGameObject;
            }
        }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

