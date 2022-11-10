using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour, ITakeDamage
{
    private Rigidbody _enemyRb;

    [SerializeField] private int damage;

    [SerializeField] private int health;

    [SerializeField] private GameObject[] explosions;

    public float Speed { get; set; }


    //private Transform _playerTransform;
    //private Transform _colliderTransform;

    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        //_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //_colliderTransform = GetComponentInChildren<Transform>();
    }

    private void Start()
    {
        _enemyRb.velocity = Vector3.forward * Speed;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    //collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
        //    Instantiate(explosions[Random.Range(0, 2)], transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}
    }

    //protected virtual void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
    //        Instantiate(explosions[Random.Range(0, 2)], transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(explosions[Random.Range(0, 2)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
