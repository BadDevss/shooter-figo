using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    private bool _canReplay = false;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().OnPlayerDeath += DisplayGameOver;
    }

    private void DisplayGameOver()
    {
        StartCoroutine(GameOverCor(2f));
    }

    private IEnumerator GameOverCor(float time)
    {
        while(time > 0)
        {
            gameOverUI.SetActive(!gameOverUI.activeSelf);
            yield return new WaitForSeconds(0.2f);
            time -= 0.2f;
        }
        gameOverUI.SetActive(false);
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreCanvas.SetActive(true);
        scoreText.text = FindObjectOfType<ScoreUI>().PlayerScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        _canReplay = true;
    }

    private void Update()
    {
        if (!_canReplay)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("HudTest");
        }
    }

}


