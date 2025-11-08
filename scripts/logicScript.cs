using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class logicScript : MonoBehaviour
{
    public Text scoreText;
    public Text newScoreText;
    public Text highscoreText;
    public int highscore = 0;
    public int score = 0;
    public bool isAlive = true;
    public bool gameIsActive = true;
    public GameObject gameOverPanel;
    public GameObject pauseButton;
    public GameObject resumeButton;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1.0f;

        highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && gameIsActive)
        {
            countScore();
            highscoreCounter();
        }


        
    }

    public void countScore()
    {
        
     
        int sum = score + 1;
    
        
        score = sum;
        scoreText.text = Convert.ToString(sum);
        newScoreText.text ="Score: " + score;
    }

    public void highscoreCounter()
    {
         
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();

            highscoreText.text = "Highscore: " + highscore;

        }
    }

    public void gameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        isAlive = false;

    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void pause()
    {
        Time.timeScale = 0;
        gameIsActive = false;
        resumeButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        gameIsActive = true;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
}
