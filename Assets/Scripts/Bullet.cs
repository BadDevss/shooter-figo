using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _bulletRb;

    [SerializeField] private float bulletSpeed = 7f;

    public int Damage { get; set; }

    private void Awake()
    {
        _bulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _bulletRb.velocity = Vector3.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ITakeDamage damagedObject = collision.gameObject.GetComponent<ITakeDamage>();

        if(damagedObject != null)
        {
            //the bullet hit something that can take damage
            damagedObject.TakeDamage(Damage);
        }
    }
}
