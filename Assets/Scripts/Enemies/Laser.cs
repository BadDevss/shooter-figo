using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject[] explosions;
    private bool _isDestroying = false;

    public void PLayLaserSoundAnim()
    {
        AudioManager.Instance.PlayClip(AudioManager.Instance.LaserSfx, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isDestroying)
        {
            ITakeDamage takeDamage = other.GetComponent<ITakeDamage>();
            if(takeDamage != null)
                takeDamage.TakeDamage(GetComponentInParent<BaseEnemy>().Damage);
            Instantiate(explosions[Random.Range(0, 2)], other.gameObject.transform.position, Quaternion.identity);
        }
    }
}
