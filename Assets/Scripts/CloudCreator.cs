using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CloudCreator : MonoBehaviour
{

    public List<GameObject> cloudPrefabs;
    public float cloudSpeed = 5.0f;
    private int _cloudCount = 0;
    private List<GameObject> _cloudList;
    private void Start()
    {
        Invoke("CreateCloud", 1);
    }

    private void Update()
    {
        for (int i = 0; i < _cloudList.Count; i++)
        {
            Vector3 pos = _cloudList[i].transform.position;
            pos.x += cloudSpeed;
            _cloudList[i].transform.position = pos;
        }
    }

    private void CreateCloud()
    {
        int randomCloud = UnityEngine.Random.Range(0, cloudPrefabs.Count);
        GameObject cloudGO = Instantiate<GameObject>(cloudPrefabs[randomCloud]);
        _cloudList.Add(cloudGO);
        cloudGO.transform.position = transform.position;
        
    }
}

// создавать по два облака так, чтобы первая пачка доходила до середины, и двигать справа налево