using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    // делегат - объект, указывающий на метод
    // с помощью делеагата можно вызывать данные метода
    public delegate void TouchPress_startedEvent(Vector2 position, float time);  
    public event TouchPress_startedEvent OnTouchPress_started;
    
    public delegate void TouchPress_canceledEvent(Vector2 position, float time);
    public event TouchPress_startedEvent OnTouchPress_canceled;

    public delegate void TouchMovementProjectile_Event(Vector2 position);
    public event TouchMovementProjectile_Event OnTouchMovementProjectile;

    private PlayerInputActions inputActions;

    public void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        inputActions.Player.TouchPress.started += TouchPress_started;
        inputActions.Player.TouchPress.canceled += TouchPress_canceled;
        inputActions.Player.TouchMovementProjectile.started += TouchMovementProjectile;
    }

    private void TouchPress_started(InputAction.CallbackContext context)
    {
        Debug.Log("TouchPress_started" + inputActions.Player.TouchPosition.ReadValue<Vector2>());
        if (OnTouchPress_started != null)
            OnTouchPress_started(inputActions.Player.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void TouchPress_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("TouchPress_canceled");
        if (OnTouchPress_canceled != null)
            OnTouchPress_canceled(inputActions.Player.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    private void TouchMovementProjectile(InputAction.CallbackContext context)
    {
        Debug.Log("TouchMovementProjectile");
        if (OnTouchMovementProjectile != null)
            OnTouchMovementProjectile(inputActions.Player.TouchMovementProjectile.ReadValue<Vector2>());
    }


}
