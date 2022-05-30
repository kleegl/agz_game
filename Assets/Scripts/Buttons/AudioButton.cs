using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public GameObject music;
    public GameObject mute;
    
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeFire;
    
    private void Awake()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        mute.SetActive(false);
        _volumeFire = _audioSource.volume;
    }
    
    public void Mute()
    {
        _soundManager.MuteAudio();
        if (music.activeSelf)
        {
            music.SetActive(false);
            mute.SetActive(true);
            _audioSource.volume = 0f;
        }
        else
        {
            music.SetActive(true);
            mute.SetActive(false);
            _audioSource.volume = _volumeFire;
        }
    }
}
