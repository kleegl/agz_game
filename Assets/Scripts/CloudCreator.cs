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
    public int startCountClouds = 6;
    public float xPointForDeleteCloud = -12.0f;
    
    private List<GameObject> _cloudList;
    
    private void Start()
    {
        _cloudList = new List<GameObject>();
        for (int i = 0; i < startCountClouds; i++)
        {
            int randomCloud = UnityEngine.Random.Range(0, cloudPrefabs.Count);
            GameObject cloudGO = Instantiate<GameObject>(cloudPrefabs[randomCloud]);
            Vector3 posAnchor = transform.position;
            posAnchor.x *= -(i/1.5f);
            cloudGO.transform.position = posAnchor;
            _cloudList.Add(cloudGO);
        }
        CreateCloud();
        Invoke("MovingClouds", 1f);
    }

    private void Update()
    {
        // Move Clouds
        if (ButtonsActions.isPause)
            return;
        for (int i = 0; i < _cloudList.Count; i++)
        {
            Vector3 pos = _cloudList[i].transform.position;
            pos.x -= cloudSpeed;
            _cloudList[i].transform.position = pos;
            DeleteCloud(i);
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

    private void DeleteCloud(int i)
    {
        if (_cloudList[i].transform.position.x <= xPointForDeleteCloud)
        {
            Destroy(_cloudList[i]);
            _cloudList.Remove(_cloudList[i]);
        }
    }
}