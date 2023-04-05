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

public class UI_Menu_Focus_ScrollView : MonoBehaviour
{
    //=-----------------=
    // Public Variables
    //=-----------------=
    [Tooltip("The selectable ui elements and their corresponding target that should be autofocused to")]
    public List<FocusableElement> focusableElements;
    


    //=-----------------=
    // Private Variables
    //=-----------------=
    private GameObject selectedElement;
    private GameObject previouslySelectedElement;
    
    
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

        var elements = contentWindow.GetComponentsInChildren<UI_Menu_SelectableFocusElement>();
        focusableElements.Clear();
        for (int i = 0; i < elements.Length; i++)
        {
            focusableElements.Add(new FocusableElement());
            focusableElements[i].selectableElement = elements[i].gameObject;
            focusableElements[i].focusTarget = elements[i].GetFocusTarget();
            // PL->FL: If you implement an auto-populating focus offset, it should probably go here
        }
    }

    private void Update()
    {
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
    
    private void SnapTo(RectTransform target, float _offset)
    {
        var pos = (contentWindow.rect.height + target.localPosition.y + _offset) / contentWindow.rect.height;
        scrollRect.verticalNormalizedPosition = pos;
    }
    
    private void UpdateFocus()
    {
        // Only update if the value has changed
        selectedElement = EventSystem.current.currentSelectedGameObject;
        if (selectedElement == null) return;
        if (selectedElement == previouslySelectedElement) return;
        
        // Foreach selectable element, if the selectedElement == currentSelectableElement, snapto(selectedElement, selectedElement.offset)
        
        // Focus the selected element's focus point
        foreach (var _element in focusableElements)
        {
            if (selectedElement == _element.selectableElement)
            {
                SnapTo(_element.focusTarget , _element.offset);
                previouslySelectedElement = EventSystem.current.currentSelectedGameObject;
            }
        }
    }
    
    
    //=-----------------=
    // External Functions
    //=-----------------=
}

