using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private IInput _playerInputs;

    private Rigidbody _playerRigidbody;

    [SerializeField] private float speed;

    private void Awake()
    {
        _playerInputs = GetComponent<IInput>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = (transform.right * _playerInputs.MoveDirection.x + transform.up * _playerInputs.MoveDirection.y).normalized * speed;
    }

}
