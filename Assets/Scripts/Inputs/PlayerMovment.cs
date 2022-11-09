using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private IInput _playerInputs;

    private Rigidbody _playerRigidbody;

    [SerializeField] private float speed;

    [SerializeField] private float minVerticalOffset = -3.064649f;

    [SerializeField] private float maxVerticalOffset = 1.500422f;

    [SerializeField] private float minHorizzontalOffset = -6.45f;

    [SerializeField] private float maxHorizzontalffset = 6.45f;

    private void Awake()
    {
        _playerInputs = GetComponent<IInput>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        Vector3 fixedDir = (transform.right * _playerInputs.MoveDirection.x + transform.up * _playerInputs.MoveDirection.y).normalized;

        if (transform.position.x >= maxHorizzontalffset && fixedDir.x > 0.1f)
        {
            fixedDir.x = 0f;
        }

        if (transform.position.x <= minHorizzontalOffset && fixedDir.x < 0.1f)
        {
            fixedDir.x = 0f;
        }

        if (transform.position.y >= maxVerticalOffset && fixedDir.y > 0.1f)
        {
            fixedDir.y = 0f;
            fixedDir.z = 0f;
        }

        if (transform.position.y <= minVerticalOffset && fixedDir.y < 0.1f)
        {
            fixedDir.y = 0f;
            fixedDir.z = 0f;
        }

        _playerRigidbody.velocity = fixedDir * speed;
        //_playerRigidbody.velocity = _playerInputs.MoveDirection * speed;
    }

}
