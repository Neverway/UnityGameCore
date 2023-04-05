using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu_SelectableFocusElement : MonoBehaviour
{
    [Header("0 = Self, 1 = Parent")]
    [Range(0,1)] public int focusTarget;

    public RectTransform GetFocusTarget()
    {
        return focusTarget switch
        {
            0 => GetComponent<RectTransform>(),
            1 => transform.parent.GetComponent<RectTransform>(),
            _ => null
        };
    }
}
