using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private Transform pivot;
    private bool _isDestroying = false;
    [SerializeField] private GameObject[] explosions;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("SpaceShip").transform;
    }

    private void Update()
    {
        Vector3 localRotation = pivot.localEulerAngles;
        Vector3 dir = _playerTransform.position - pivot.position;

        float xAngle = 0f;

        //if(dir.y > 0)
        //    xAngle = Mathf.Atan2(dir.y, -dir.z) * Mathf.Rad2Deg;

        localRotation.x = xAngle;
        transform.localEulerAngles = localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isDestroying)
        {
            _isDestroying = true;
            StartCoroutine(AutoDestroyCor());
            Debug.Log("PROCA TROIAAAAAAAAAAAAAAA");
        }
    }

    private IEnumerator AutoDestroyCor()
    {
        GetComponentInParent<SpriteRenderer>().sortingOrder = 100;      
        yield return new WaitForSeconds(0.2f);
        Instantiate(explosions[Random.Range(0, 2)], pivot.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
        yield return null;
    }

}
