using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonsAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject twitter;
    public GameObject git;
    public GameObject start;
    public GameObject options;
    public GameObject quit;
    
    
    
    //сделать родительский класс для всех кнопок и override функции 
    // почитать про ивенты

    public void OpenHitHubLink()
    {
        Application.OpenURL("https://github.com/JenyaMefedov/agz");
    }

    public void OpenTwitterLink()
    {
        Application.OpenURL("https://twitter.com/j_mefedov");
    }

    public void OnStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnOptions()
    {
        print("option");
    }

    public void OnQuit()
    { 
        Application.Quit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        eventData.selectedObject.transform.localScale *= 0.8f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        eventData.selectedObject.transform.localScale /= 0.8f;
    }
}
