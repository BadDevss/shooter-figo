using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health;
    public System.Action<int> OnDamage;
    public System.Action OnPlayerDeath;

    public void TakeDamage(int damage)
    {
        health -= damage;

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
}
