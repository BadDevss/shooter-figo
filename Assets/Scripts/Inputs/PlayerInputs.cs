using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour, IInput
{
    Inputs _inputActions;

    public Vector2 MoveDirection { get; private set; }

    private void Awake()
    {
        _inputActions = new Inputs();
    }

    private void Start()
    {
        _inputActions.Player.Movment.performed += ctx =>
        {

            //Vector2 input = ctx.ReadValue<Vector2>().normalized;

            //Vector3 fixedInput = input;

            //fixedInput.z = input.y * Mathf.Sin(Mathf.Deg2Rad * 18f) * Mathf.Rad2Deg;

            //MoveDirection = fixedInput.normalized;

            //Debug.Log(fixedInput);
            MoveDirection = ctx.ReadValue<Vector2>().normalized;
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
