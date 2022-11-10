using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int damage;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
