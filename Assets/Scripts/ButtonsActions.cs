using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ButtonsActions : Buttons
{
    public static bool deleteFireList;
    
    public float transitionDelayTime = 5.0f;
    public static bool isPause;
    private Animator _animator;
    private bool isMenu;
    private void Awake()
    {
        _animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        deleteFireList = false;
        isPause = false;
        isMenu = true;
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
        StartCoroutine(DelayLoadTransitionInGame());
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnPause()
    {
        if (isPause == false)
        {
            Time.timeScale = 0;   
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;   
            isPause = false;
        }
    }

    public void OnApplicationQuit()
    {
        print("Application was end");
    }

    public void OnMenu()
    {
        StartCoroutine(DelayLoadTransitionInMenu());
    }

    public void OnReplay()
    {
        GamePlay.callsReplayWindow = 0;
        deleteFireList = true;
        StartCoroutine(DelayLoadTransitionInMenu());
    }

    IEnumerator DelayLoadTransitionInGame()
    {
        yield return new WaitForSeconds(transitionDelayTime);
        _animator.Play("TransitionOut");
        SceneManager.LoadScene("Game");
        isMenu = false;
    }

    IEnumerator DelayLoadTransitionInMenu()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1;
        }
        yield return new WaitForSeconds(transitionDelayTime);
        _animator.Play("TransitionIn");
        SceneManager.LoadScene("Menu");
        isMenu = true;
    }
}
