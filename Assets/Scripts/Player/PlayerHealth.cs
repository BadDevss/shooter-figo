using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health;
    public System.Action<int> OnDamage;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
            health = 0;

        OnDamage?.Invoke(health);
        Debug.Log("Player took: " + damage + " damage");
    }
}
