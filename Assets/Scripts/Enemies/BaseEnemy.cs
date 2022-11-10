using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour, ITakeDamage
{
    protected Rigidbody _enemyRb;

    [SerializeField] private int damage;

    [SerializeField] private int health;

    [SerializeField] private GameObject[] explosions;

    public float Speed { get; set; }


    protected Transform _playerTransform;
    [SerializeField] private Transform pivot;
    private bool _isDestroying = false;
    //[SerializeField] private GameObject[] explosions;

    protected virtual void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Start()
    {
        _enemyRb.velocity = Vector3.forward * Speed;
    }

    protected virtual void Update()
    {
        if( (transform.position - _playerTransform.position).z <= -5f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(explosions[Random.Range(0, 2)], pivot.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isDestroying)
        {
            _isDestroying = true;
            StartCoroutine(AutoDestroyCor());
            Debug.Log("PROCA TROIAAAAAAAAAAAAAAA");
        }
    }

    protected virtual IEnumerator AutoDestroyCor()
    {
        GetComponentInParent<SpriteRenderer>().sortingOrder = 100;
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosions[Random.Range(0, 2)], pivot.position, Quaternion.identity);
        //Destroy(transform.parent.gameObject);
        Destroy(gameObject);
        yield return null;
    }
}
