using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static Action<bool, int, Vector2> OnClick;

    private void HandleButton(int button)
    {
        if (Input.GetMouseButtonDown(button))
        {
            if (OnClick != null)
            {
                OnClick(true, button, Input.mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(button))
        {
            if (OnClick != null)
            {
                OnClick(false, button, Input.mousePosition);
            }
        }
    }
    
    private void Update()
    {
        HandleButton(0);
        HandleButton(1);
    }
}
