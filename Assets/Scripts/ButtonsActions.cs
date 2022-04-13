using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : Buttons
{
    public float transitionDelayTime = 5.0f;
    private Animator animator;
    

    private void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }
    
    public void OnOpenTwitterLink()
    {
        Application.OpenURL("https://twitter.com/j_mefedov");
    }

    public void OnOpenHitGubLink()
    {
        Application.OpenURL("https://github.com/JenyaMefedov/agz");
    }

    public void OnOption()
    {
        print("Options was opened");
    }

    public void OnPlay()
    {
        StartCoroutine(DelayLoadScene());
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        pauseStatus = true;
    }

    private void OnApplicationQuit()
    {
        print("Application ended");
    }

    IEnumerator DelayLoadScene()
    {
        animator.Play("TransitionIn");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene("Game");
    }
}
