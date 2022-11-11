using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] explosions;
    private bool _isDestroying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isDestroying)
        {
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(GetComponent<BaseEnemy>().Damage);
            Instantiate(explosions[Random.Range(0, 2)], other.gameObject.transform.position, Quaternion.identity);
        }
    }
}
