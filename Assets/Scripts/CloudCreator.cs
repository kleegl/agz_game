using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class CloudCreator : MonoBehaviour
{

    public List<GameObject> cloudPrefabs;
    public float cloudSpeed = 5.0f;
    public float timeBetweenSpawnClouds = 5f;
    
    private List<GameObject> _cloudList;
    
    private void Start()
    {
        _cloudList = new List<GameObject>();
        CreateCloud();
        Invoke("MovingClouds", 1f);


    }

    private void Update()
    {
        for (int i = 0; i < _cloudList.Count; i++)
        {
            Vector3 pos = _cloudList[i].transform.position;
            pos.x -= cloudSpeed;
            _cloudList[i].transform.position = pos;
        }
    }

    private void CreateCloud()
    {
        int randomCloud = UnityEngine.Random.Range(0, cloudPrefabs.Count);
        GameObject cloudGO = Instantiate<GameObject>(cloudPrefabs[randomCloud]);
        cloudGO.transform.position = transform.position;
        _cloudList.Add(cloudGO);
        Invoke("CreateCloud", timeBetweenSpawnClouds);
    }
}

// создавать по два облака так, чтобы первая пачка доходила до середины, и двигать справа налево