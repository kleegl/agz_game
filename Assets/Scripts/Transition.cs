using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transistionDelayTime = 0.2f;

    private void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(DelayLoadTransition());
    }

    IEnumerator DelayLoadTransition()
    {
        animator.Play("TransitionIn");
        yield return new WaitForSeconds(transistionDelayTime);
    }
}
