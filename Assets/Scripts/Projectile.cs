using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GamePlay _gamePlayScript;
    private GameObject ground;
    private Camera _camera;
    private SoundManager _soundManager;

    private void Awake()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }


    private void Start()
    {
        _camera = Camera.main;
        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    private void Update()
    {
        _gamePlayScript = _camera.GetComponent<GamePlay>();
        
        if(transform.position.y < ground.transform.position.y)
            Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
            Destroy(this.gameObject);

        if (other.transform.CompareTag("Fire"))
        {
            _soundManager.PlaySteam();
            Destroy(this.gameObject);
            _gamePlayScript.DeleteSingleFire(other);

            GamePlay.Score += 1;
        }
    }
}
