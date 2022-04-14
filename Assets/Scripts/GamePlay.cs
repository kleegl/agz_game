using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;
using Random = UnityEngine.Random;

public class GamePlay : MonoBehaviour
{
    public static int Score = 0;
    public static int callsReplayWindow = 0;
    
    public float secondsBetweenCreateFire = 1.0f;
    public List <GameObject> windowsList;
    public GameObject firePrefab;
    public GameObject replayWindowPrefab;
    public GameObject canvas;

    [Header("UI")] 
    public Text scoreText;
    public Text timeInGame;
    
    private List<GameObject> _fireList;
    private int callsCount = 0;
    
    

    private void Awake()
    {
        canvas = GameObject.Find("CanvasGame");
    }

    private void Start()
    {
        _fireList = new List<GameObject>();
        Invoke("CreateFire", 1f);
    }

    private void Update()
    {
        String time = $"{Time.time:f2}";
        timeInGame.text = time;
        if (callsCount > 10)
        {
            secondsBetweenCreateFire -= 0.05f;
            callsCount = 0;
        }

        if (_fireList.Count > 10)
        {
            if (ButtonsActions.isPause == false)
            {
                ReplayGameWindow();
            }
        }
        scoreText.text = $"{Score}";
    }

    private void CreateFire()
    {
        GameObject fireGO = Instantiate<GameObject>(firePrefab);
        int window = Random.Range(0, windowsList.Count);
        fireGO.transform.position = windowsList[window].transform.position;
        _fireList.Add(fireGO);
        callsCount += 1;
        Invoke("CreateFire", secondsBetweenCreateFire);
    }
    
    private void ReplayGameWindow()
    {
        if (callsReplayWindow == 0)
        {
            callsReplayWindow += 1;
            Time.timeScale = 0;
            ButtonsActions.isPause = true;
            GameObject pauseWindow = Instantiate<GameObject>(replayWindowPrefab);
            pauseWindow.transform.parent = canvas.transform;
        }
        return;
    }

    private void DeleteFire()
    {
        if (ButtonsActions.deleteFireList == true)
            _fireList.Clear();
    }
}
