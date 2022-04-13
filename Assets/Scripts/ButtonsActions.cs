using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : Buttons
{
    public float transitionDelayTime = 5.0f;
    private Animator animator;
    private bool isMenu;
    private bool isPause;
    private void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        isMenu = true;
        isPause = false;
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

        Time.timeScale = 1;
        isPause = false;
    }

    public void OnApplicationQuit()
    {
        print("Application was end");
    }

    public void OnMenu()
    {
        StartCoroutine(DelayLoadTransitionInMenu());
    }

    IEnumerator DelayLoadTransitionInGame()
    {
        yield return new WaitForSeconds(transitionDelayTime);
        animator.Play("TransitionOut");
        SceneManager.LoadScene("Game");
        isMenu = false;
    }

    IEnumerator DelayLoadTransitionInMenu()
    {
        yield return new WaitForSeconds(transitionDelayTime);
        animator.Play("TransitionIn");
        SceneManager.LoadScene("Menu");
        isMenu = true;
    }
}
