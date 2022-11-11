using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    [SerializeField] private Animator shootingAnimator;

    [SerializeField] private BaseShoot shootType;

    [SerializeField] private Transform[] firePoitns;

    [SerializeField] private float fireRate = 0.5f;

    private float _timeElapsed = 0f;

    private void Awake()
    {
        _playerInputs = GetComponent<PlayerInputs>();
    }

    private void Update()
    {
        if(_timeElapsed > 0f)
            _timeElapsed -= Time.deltaTime;

        if (_playerInputs.IsFiring)
            shootingAnimator.SetBool("IsShooting", true);
        else
            shootingAnimator.SetBool("IsShooting", false);

        if(_playerInputs.IsFiring && _timeElapsed <= 0f)
        {
            shootType.Fire(firePoitns);
            AudioManager.Instance.PlayClip(AudioManager.Instance.BulletSfx, gameObject, 0.4f);
            _timeElapsed = fireRate;
        }
    }
}
