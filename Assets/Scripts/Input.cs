using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public GameObject projectilePrefab;
    public float speedProjectile = 10.0f;
    
    private GameObject _projectileGO;
    private float _zAxis;
    private Camera _camera;
    private CircleCollider2D _circleColl;
    private Rigidbody2D _rb;
    private CircleCollider2D _colliderHalo;
    private Vector3 _centerOfZone = Vector3.zero;
    private Vector3 _posInGame = Vector3.zero;
    
    private void Start()
    {
        _camera = Camera.main;
        _colliderHalo = transform.GetComponent<CircleCollider2D>();
        _zAxis = transform.position.z + 5;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print(eventData.position);
        _colliderHalo.enabled = false;
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
        _colliderHalo.enabled = true;
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
        _centerOfZone = transform.position;
        Vector3 mouseDelta = _centerOfZone - _posInGame;
        _rb.velocity = new Vector2(-mouseDelta.x, -mouseDelta.y) * speedProjectile;
    }
}
