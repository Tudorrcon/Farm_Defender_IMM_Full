using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winningText;
    public TextMeshProUGUI levelWonText;
    public Button titleScreenButton;
    public Button nextLevelButton;
    public bool isGameActive;
    public int scoreTotal = 0;
    public int livesTotal = 6;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreTotal += scoreToAdd;
        scoreText.text = "Score: " + scoreTotal;
    }
    public void UpdateLives()
    {
        livesTotal--;
        livesText.text = "Lives: " + livesTotal;
        if (livesTotal==0)
        {
            GameOver();
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        titleScreenButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RoundWon()
    {
        nextLevelButton.gameObject.SetActive(true);
        levelWonText.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void Winning()
    {
        titleScreenButton.gameObject.SetActive(true);
        winningText.gameObject.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0;
    }

    

}
