using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Player took: " + damage + " damage");
    }
}
