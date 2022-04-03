using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    public float speed = 2f;
    private PlayerInputActions _playerInputActions;


    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable(); //Player - ����� ��������
        //playerInputActions.Player.Shoot.performed += Shoot;

        //playerInputActions.Player.Movement.performed += Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 move = context.ReadValue<Vector2>();
        transform.position = move * speed;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        
    }
}