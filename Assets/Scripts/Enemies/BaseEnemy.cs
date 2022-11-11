using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour, ITakeDamage
{
    protected Rigidbody _enemyRb;

    [SerializeField] private int damage;

    public int Damage { get => damage; }

    [SerializeField] private int health;

    [SerializeField] private int points;

    [SerializeField] private GameObject[] explosions;

    public float Speed { get; set; }


    protected Transform _playerTransform;
    [SerializeField] private Transform pivot;
    private bool _isDestroying = false;

    public System.Action<int> OnEnemyDeath;

    protected virtual void Awake()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _playerTransform.gameObject.GetComponent<PlayerHealth>().OnPlayerDeath += PlayerDeath;
    }

    private void PlayerDeath()
    {       
        Instantiate(explosions[Random.Range(0, 2)], pivot.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        _enemyRb.velocity = Vector3.forward * Speed;
    }

    protected virtual void Update()
    {
        if( (transform.position - _playerTransform.position).z <= -5f)
        {
            _playerTransform.gameObject.GetComponent<PlayerHealth>().OnPlayerDeath -= PlayerDeath;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Instantiate(explosions[Random.Range(0, 2)], pivot.position, Quaternion.identity);
            OnEnemyDeath?.Invoke(points);
            _playerTransform.gameObject.GetComponent<PlayerHealth>().OnPlayerDeath -= PlayerDeath;
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isDestroying)
        {
            Debug.Log("PROCA TROIAAAAAAAAAAAAAAA");
            _isDestroying = true;
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(Damage);
            StartCoroutine(AutoDestroyCor());      
        }
    }

    protected virtual IEnumerator AutoDestroyCor()
    {
        GetComponentInParent<SpriteRenderer>().sortingOrder = 100;
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosions[Random.Range(0, 2)], pivot.position + new Vector3(0f,0f,3f), Quaternion.identity);
        //Destroy(transform.parent.gameObject);
        _playerTransform.gameObject.GetComponent<PlayerHealth>().OnPlayerDeath -= PlayerDeath;
        Destroy(gameObject);
        yield return null;
    }
}
