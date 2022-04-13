using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayButton : Buttons
{
    public Animator animator;
    public float transistionDelayTime = 5f;

    private void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public void OnPlay()
    {
        StartCoroutine(DelayLoadScene());
    }

    IEnumerator DelayLoadScene()
    {
        animator.Play("TransitionOut");
        yield return new WaitForSeconds(transistionDelayTime);
        SceneManager.LoadScene("Game");
    }
}
