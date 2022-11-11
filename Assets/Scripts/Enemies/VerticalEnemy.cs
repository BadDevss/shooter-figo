using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : BaseEnemy
{
    //private Rigidbody _enemyRb;

    [SerializeField] private float maxVerticalHeight;
    [SerializeField] private float minVerticalHeight;
    //[SerializeField] private float speed;
    private float _speed;
    private int dir = 1;

    //private void Awake()
    //{
    //    _enemyRb = GetComponent<Rigidbody>();
    //}

    protected override void Start()
    {
        dir = Random.Range(1, 3) % 2 == 0 ? 1 : -1;
        _speed = 15f * Speed / 23f;
    }

    protected override void Update()
    {
        base.Update();

        if (transform.position.y >= maxVerticalHeight)
            dir = -1;
        else if(transform.position.y <= minVerticalHeight)
            dir = 1;

        Vector3 vel = _enemyRb.velocity;
        vel.y = _speed * dir;
        _enemyRb.velocity = vel;      
    }

    public override void UpgradeEnemey(EnemiesUpgrade enemiesUpgrade)
    {       
        base.UpgradeEnemey(enemiesUpgrade);
        _speed = 15f * Speed / 23f;
    }
}
