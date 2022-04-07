using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GamePlay : MonoBehaviour
{
    public static int Score = 0;
    
    public float secondsBetweenCreateFire = 1.0f;
    public List <GameObject> windowsList;
    public GameObject firePrefab;

    [Header("UI")] 
    public Text scoreText;

    private List<GameObject> _fireList;
    private int callsCount = 0;

    private void Start()
    {
        _fireList = new List<GameObject>();
        Invoke("CreateFire", 1f);
    }

    private void Update()
    {
        if (callsCount > 10)
        {
            secondsBetweenCreateFire -= 0.02f;
            callsCount = 0;
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
}
