using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletRb;

    [SerializeField] private float bulletSpeed = 7f;

    [SerializeField] private float autoDestroyTimer = 2f;

    public int Damage { get; set; }

    private void Awake()
    {
        _bulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _bulletRb.velocity = Vector3.forward * bulletSpeed;
        Invoke("AutoDestroy", autoDestroyTimer);
    }

    private void Update()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x += 0.005f;
        currentScale.y += 0.005f;
        transform.localScale = currentScale;
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            return;

        ITakeDamage damagedObject = other.gameObject.GetComponent<ITakeDamage>();

        if (damagedObject != null)
        {
            //the bullet hit something that can take damage
            damagedObject.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
