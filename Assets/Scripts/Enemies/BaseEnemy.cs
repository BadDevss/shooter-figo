using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    private Rigidbody _enemyRb;

    [SerializeField] private int damage;

    public float Speed { get; set; }

    //[SerializeField] private float spped = 1f;
    //private float _elapsedTime = 0f;

    //public Rigidbody PlayerRb { get; set; }

    //[SerializeField] private float speed;

    private Transform _playerTransform;
    private Transform _colliderTransform;

    private void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _colliderTransform = GetComponentInChildren<Transform>();
    }

    private void Start()
    {
        _enemyRb.velocity = Vector3.forward * Speed;
    }

    //private void Update()
    //{
    //    Vector3 playerVelocity = PlayerRb.velocity;
    //    _enemyRb.velocity = new Vector3(playerVelocity.x, playerVelocity.y, Speed);
    //}

    private void Update()
    {
        //_elapsedTime -= Time.deltaTime;

        //if(_elapsedTime <= 0f)
        //{
        //    Vector3 scale = transform.localScale;
        //    scale.x += 1f;
        //    scale.y += 1f;
        //    transform.localScale = scale;

        //    if (transform.localScale.x == 10f)
        //        Destroy(gameObject);

        //    _elapsedTime = spped;
        //}


    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
