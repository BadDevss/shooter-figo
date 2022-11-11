using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject[] bars;
    [SerializeField] private GameObject characterUI;
    private int _index = 0;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().OnDamage += LoseLife;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().OnPlayerDeath += DisappearUI;
    }

    private void LoseLife(int damage)
    {
        if (_index >= bars.Length)
            return;

        bars[_index].SetActive(false);
        _index++;
    }

    private void DisappearUI()
    {
        gameObject.SetActive(false);
        characterUI.SetActive(false);
    }
}
