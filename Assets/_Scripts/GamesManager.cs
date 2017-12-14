using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour {

    public static GamesManager Instance;

    [Header("Property")]
    public int score;
    public int highScore;
    public int lives;

    [Header("UI")]
    public GameObject PanelGameOver;
    public Text scoreLabel;
    public Text highScoreLabel;
    public Text currentScoreLabel;

    public bool isGameOver;

    private void Awake()
    {
        Instance = this;
    }

    void Start () {
        highScore = PlayerPrefs.GetInt("highScore");
        score = 0;
        currentScoreLabel.text = score.ToString();
	}

    public void AddScore(int value)
    {
        score += value;
        currentScoreLabel.text = score.ToString();
    }

    public void DecreaseLives(int value)
    {
        lives -= value;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
        }
        PanelGameOver.SetActive(true);
        scoreLabel.text = "Score : " + score;
        highScoreLabel.text = "High Score : " + highScore;
        isGameOver = true;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void OpenScene(string scenename)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scenename);
    }
}
