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
    private Vector3 _lifeZone = Vector3.zero;
    
    private void Start()
    {
        _camera = Camera.main;
        _zAxis = transform.position.z + 5;
        _circleColl = GetComponent<CircleCollider2D>();
        _lifeZone = _circleColl.bounds.extents;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        CreateProjectile();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _posInGame = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, _zAxis));
        if ((_posInGame.x > _lifeZone.x))
        {
            Destroy(_projectileGO);
            eventData.Reset();
        }
        _projectileGO.transform.position = _posInGame;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(_projectileGO == null)
            eventData.Reset();
        ShootProjectile();
    }

    private void CreateProjectile()
    {
        _projectileGO = Instantiate<GameObject>(projectilePrefab);
        _projectileGO.transform.position = this.transform.position;
        _rb = _projectileGO.GetComponent<Rigidbody2D>();
    }
    
    private void ShootProjectile()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 mouseDelta = _centerOfZone.position - _posInGame;
        _rb.velocity = -mouseDelta * speedProjectile;
        _rb.isKinematic = false;
    }
}
