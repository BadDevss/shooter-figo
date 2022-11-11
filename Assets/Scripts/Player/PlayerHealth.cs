using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health;
    [SerializeField] private Material hitMaterial;
    private Material _defaultMaterial;
    public System.Action<int> OnDamage;
    public System.Action OnPlayerDeath;

    private void Awake()
    {
        _defaultMaterial = GetComponentInChildren<SpriteRenderer>().material;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(TakeDamageCor());

        if (health <= 0)
        {
            Debug.Log("Player Died");
            health = 0;
            OnDamage?.Invoke(health);
            OnPlayerDeath?.Invoke();
            DeactiveScripts();
        }           

        OnDamage?.Invoke(health);
        Debug.Log("Player took: " + damage + " damage");
    }

    private void DeactiveScripts()
    {
        GetComponent<PlayerInputs>().enabled = false;
        GetComponent<PlayerMovment>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<cameraHorizon>().enabled = false;
        GameObject.FindGameObjectWithTag("SpaceShip").SetActive(false);
    }

    private IEnumerator TakeDamageCor()
    {
        GetComponentInChildren<SpriteRenderer>().material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<SpriteRenderer>().material = _defaultMaterial;
    }
}
