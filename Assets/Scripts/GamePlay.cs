using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        replayWindowPrefab.SetActive(false);
    }

    private void Start()
    {
        _fireList = new List<GameObject>();
        Invoke("CreateFire", 2f);
    }

    private void Update()
    {
        String time = $"{Time.timeSinceLevelLoad:f2}";
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
        
        if(ButtonsActions.deleteFireList)
            DeleteFireList();
        
        scoreText.text = $"{Score}";
    }

    private void CreateFire()
    {
        GameObject fireGO = Instantiate<GameObject>(firePrefab);
        int window = Random.Range(0, windowsList.Count);
        fireGO.transform.localPosition = windowsList[window].transform.position;
        _fireList.Add(fireGO);
        callsCount += 1;
        if ((ButtonsActions.isPause == false) && (callsReplayWindow == 0))
        {
            Invoke("CreateFire", secondsBetweenCreateFire);
        }
    }
    
    private void ReplayGameWindow()
    {
        if (callsReplayWindow == 0)
        {
            callsReplayWindow += 1;
            ButtonsActions.isPause = true;
            replayWindowPrefab.SetActive(true);
        }
    }

    public void DeleteFireList()
    {
        foreach (GameObject fire in _fireList)
            Destroy(fire);
        _fireList.Clear();
        ButtonsActions.deleteFireList = false;
        callsReplayWindow = 0;
    }
}
