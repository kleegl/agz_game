using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioSwing = new AudioClip[4];
    public AudioClip[] audioSteam = new AudioClip[3];
    public float volume = 0.01f;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySwing()
    {
        int randomTrack = UnityEngine.Random.Range(0, audioSwing.Length);
        _audioSource.PlayOneShot(audioSwing[randomTrack], volume);
    }

    public void PlaySteam()
    {
        int randomTrack = UnityEngine.Random.Range(0, audioSteam.Length);
        _audioSource.PlayOneShot(audioSteam[randomTrack], volume);
    }
}
