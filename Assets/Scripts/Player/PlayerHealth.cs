using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int health;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private AudioSource engineSource;
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

            int previousHighScore = PlayerPrefs.GetInt("HighScore");
            int currentScore = FindObjectOfType<ScoreUI>().PlayerScore;

            if (currentScore > previousHighScore)
                PlayerPrefs.SetInt("HighScore", currentScore);

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

        AudioSource audioSource = GameObject.FindGameObjectWithTag("SpaceShip").GetComponent<AudioSource>();
        audioSource.clip = AudioManager.Instance.EngineDownSfx;
        audioSource.priority = 256;
        audioSource.loop = false;
        audioSource.Play();

        //engineSource.clip = AudioManager.Instance.EngineDownSfx;
        //engineSource.priority = 256;
        //engineSource.loop = false;
        //engineSource.Play();

        GameObject.FindGameObjectWithTag("SpaceShip").GetComponent<SpriteRenderer>().enabled = false;
    }

    private IEnumerator DecrementPitchCor()
    {
        AudioSource audioSource = GameObject.FindGameObjectWithTag("SpaceShip").GetComponent<AudioSource>();

        while(audioSource.pitch > -2f)
        {
            audioSource.pitch -= 0.1f;
            Debug.Log(audioSource.pitch);
            yield return new WaitForSeconds(0.5f);
        }
        audioSource.enabled = false;
        yield break;
    }

    private IEnumerator TakeDamageCor()
    {
        GetComponentInChildren<SpriteRenderer>().material = hitMaterial;
        yield return new WaitForSeconds(0.1f);
        GetComponentInChildren<SpriteRenderer>().material = _defaultMaterial;
    }
}
