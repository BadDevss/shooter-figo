using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private IInput _playerInputs;

    private Rigidbody _playerRigidbody;

    [SerializeField] private float movmentSpeed;

    [SerializeField] private float forwardSpeed = 5f;

    [SerializeField] private float minVerticalOffset = -3.064649f;

    [SerializeField] private float maxVerticalOffset = 1.500422f;

    [SerializeField] private float minHorizzontalOffset = -6.45f;

    [SerializeField] private float maxHorizzontalffset = 6.45f;

    [SerializeField] private float horizzontalRotation = 20f;

    [SerializeField] private Transform spaceShip;

    public float ForwardSpeed { get => forwardSpeed * movmentSpeed; }

    private Animator _spaceShiptAnim;

    private void Awake()
    {
        _playerInputs = GetComponent<IInput>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _spaceShiptAnim = GetComponentInChildren<Animator>();
        GetComponent<PlayerHealth>().OnPlayerDeath += PLayerDeath;
    }

    private void PLayerDeath()
    {
        _playerRigidbody.velocity = Vector3.forward * forwardSpeed * movmentSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 fixedDir = (transform.right * _playerInputs.MoveDirection.x + transform.up * _playerInputs.MoveDirection.y).normalized;

        fixedDir.z = forwardSpeed;

        if (fixedDir.x > 0.5f && fixedDir.x != 0f)
        {
            Vector3 angles = spaceShip.localEulerAngles;
            angles.z = horizzontalRotation;
            spaceShip.localEulerAngles = -angles;
        }
        else if (fixedDir.x < -0.5f && fixedDir.x != 0f)
        {
            Vector3 angles = spaceShip.localEulerAngles;
            angles.z = horizzontalRotation;
            spaceShip.localEulerAngles = angles;
        }
        else
        {
            Vector3 angles = spaceShip.localEulerAngles;
            angles.z = 0f;
            spaceShip.localEulerAngles = angles;
        }     

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
        }

        if (transform.position.y <= minVerticalOffset && fixedDir.y < 0.1f)
        {
            fixedDir.y = 0f;
        }

        _spaceShiptAnim.SetFloat("yDir", fixedDir.y);

        _playerRigidbody.velocity = fixedDir * movmentSpeed;
    }

}
