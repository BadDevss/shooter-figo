using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, IInput
{
    Inputs _inputActions;

    public Vector2 MoveDirection { get; private set; }

    public bool IsFiring { get ; private set; }

    private void Awake()
    {
        _inputActions = new Inputs();
    }

    private void Start()
    {
        _inputActions.Player.Movment.performed += ctx =>
        {
            MoveDirection = ctx.ReadValue<Vector2>().normalized;
        };

        _inputActions.Player.Attack.performed += ctx =>
        {
            IsFiring = true;
        };

        _inputActions.Player.Attack.canceled += ctx =>
        {
            IsFiring = false;
        };
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
