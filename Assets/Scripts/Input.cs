using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject projectilePrefab;
    public float speedProjectile = 10.0f;
    public Transform _centerOfZone;
    
    private GameObject _projectileGO;
    private float _zAxis;
    private Camera _camera;
    private CircleCollider2D _circleColl;
    private Rigidbody2D _rb;

    private Vector3 _posInGame = Vector3.zero;
    
    private void Start()
    {
        _camera = Camera.main;
        _zAxis = transform.position.z + 5;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print(eventData.position);
        CreateProjectile();
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("DRAG");
        _posInGame = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, _zAxis));
        _projectileGO.transform.position = _posInGame;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _circleColl.enabled = true;
        ShootProjectile();
    }

    private void CreateProjectile()
    {
        _projectileGO = Instantiate<GameObject>(projectilePrefab);
        _projectileGO.transform.position = this.transform.position;
        _circleColl = _projectileGO.GetComponent<CircleCollider2D>();
        _circleColl.enabled = false;
        _rb = _projectileGO.GetComponent<Rigidbody2D>();
    }
    
    private void ShootProjectile()
    {
        Vector3 mouseDelta = _centerOfZone.position - _posInGame;
        // _rb.velocity = new Vector2(-mouseDelta.x, -mouseDelta.y) * speedProjectile;
        _rb.velocity = mouseDelta * speedProjectile;
    }
}
