using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UNUSED SCRIPT FOR HIDING UI ELEMENTS
/// </summary>
public class HideUI : MonoBehaviour
{
    CanvasGroup canvas;

    private void start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    private void Hide()
    {
        canvas.alpha = 0f; 
        canvas.blocksRaycasts = false; 
    }

    private void Show()
    {
        canvas.alpha = 1f;
        canvas.blocksRaycasts = true;
    }

    private void OnMouseOver()
    {
        print("Over");
        Show();
       
    }

    private void OnMouseExit()
    {
        Hide();
        
    }

}
