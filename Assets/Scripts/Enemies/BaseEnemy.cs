using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    private Rigidbody _enemyRb;

    [SerializeField] private int damage;

    public float Speed { get; set; }

    //[SerializeField] private float speed;

    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _enemyRb.velocity = Vector3.forward * Speed;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
