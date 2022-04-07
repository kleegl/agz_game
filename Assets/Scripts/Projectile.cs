using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject ground;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
            Destroy(this.gameObject);

        if (other.transform.CompareTag("Fire"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.y < ground.transform.position.y)
            Destroy(this.gameObject);
    }
}
