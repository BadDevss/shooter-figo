using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private int _currentScore = 0;
    public int PlayerScore { get => _currentScore; }
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        FindObjectOfType<Spawner>().OnScoreAdded += AddScore;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().OnPlayerDeath += DeactiveUI;
    }

    private void DeactiveUI()
    {
        _scoreText.enabled = false;
    }

    private void AddScore(int amount)
    {
        _currentScore += amount;
        _scoreText.text = _currentScore.ToString();
    }
}
