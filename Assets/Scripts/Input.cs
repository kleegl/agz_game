using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
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
    private Vector3 _centerZone = Vector3.zero;
    private float[] _boundsX;
    private float[] _boundsY;
    private bool _canCreateProjectile;
    private IPointerDownHandler _pointerDownHandlerImplementation;

    private void Start()
    {
        _camera = Camera.main;
        _zAxis = transform.position.z + 5;
        _circleColl = GetComponent<CircleCollider2D>();
        _centerZone = _circleColl.bounds.center;
        _boundsX = new []{_centerZone.x + _circleColl.radius, _centerZone.x - _circleColl.radius};
        _boundsY = new []{_centerZone.y + _circleColl.radius, _centerZone.y - _circleColl.radius};
        _canCreateProjectile = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    //     if ((UnityEngine.Input.GetMouseButton(0)) && (_canCreateProjectile))
    //     {
    //         _canCreateProjectile = false;
    //         CreateProjectile();
    //     }
    }
    
    // private void Update()
    // {
    //     if ((UnityEngine.Input.GetMouseButton(0)) && (_canCreateProjectile))
    //     {
    //         _canCreateProjectile = false;
    //         CreateProjectile();
    //     }
    // }

    public void OnDrag(PointerEventData eventData)
    {
        _posInGame = _camera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, _zAxis));

        if ((UnityEngine.Input.GetMouseButton(0)) && (_canCreateProjectile))
        {
            _canCreateProjectile = false;
            CreateProjectile();
        }
        
        if ((_posInGame.x > _boundsX[0]) || (_posInGame.x < _boundsX[1]) || (_posInGame.y > _boundsY[0]) ||
            (_posInGame.y < _boundsY[1]))
        {
            eventData.pointerDrag = null;
            ShootProjectile();
        }
        
        if (_projectileGO == null)
        {
            eventData.pointerDrag = null;
            return;
        }
        _projectileGO.transform.position = _posInGame;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(_projectileGO == null)
            eventData.Reset();
        ShootProjectile();
        _canCreateProjectile = true;
    }

    private void CreateProjectile()
    {
        if ((GamePlay.callsReplayWindow == 1) || (ButtonsActions.isPause)) return;
        _projectileGO = Instantiate<GameObject>(projectilePrefab);
        // _projectileGO.transform.position = this.transform.position;
        _projectileGO.transform.position = _posInGame;
        _rb = _projectileGO.GetComponent<Rigidbody2D>();
    }
    
    private void ShootProjectile()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 mouseDelta = _centerOfZone.position - _posInGame;
        _rb.velocity = -mouseDelta * speedProjectile;
        _rb.isKinematic = false;
        _canCreateProjectile = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if ((UnityEngine.Input.GetMouseButton(0)) && (_canCreateProjectile))
        {
            _canCreateProjectile = false;
            CreateProjectile();
        }
    }
}