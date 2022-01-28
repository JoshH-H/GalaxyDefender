using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalDataLvl1 : MonoBehaviour
{
    public GameObject Player;
    static public int lives = 3;
    static public bool paused = false;
    static public bool gameOver = false;
    static public int score;
    public GameObject[] hearts;
    public GameObject[] shields;
    public AudioSource battleTheme;
    public AudioSource loseTheme;
    public GameObject pauseMenu;
    public GameObject gameWin;
    public GameObject gamedie;
    public Text scoreText;
    

    private void Awake()
    {
        Player.SetActive(true);
        gameOver = false;
        gameWin.SetActive(false);
        gamedie.SetActive(false);
        lives = 3;
        score = 0;
        UpdateLives();
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetScore()
    {
        scoreText.text = score.ToString();
    }
    public void UpdateLives()
    {
        for(int i = 0; i < hearts.Length;i++)
        {
            if (lives > i)
            {
                hearts[i].SetActive(false);
                shields[i].SetActive(true);
            } 
            else
            {
                hearts[i].SetActive(true);
                shields[i].SetActive(false);
            }
        }

        if(lives <= 0)
        {
            EndGame();
        }
    }

    public void GameWin()
    {
        StartCoroutine("EndLevel");
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(3);
        battleTheme.Pause();
        Player.SetActive(false); 
        Time.timeScale = 0f;
        Debug.Log("Answered");
        Player.GetComponent<PlayerMove>().enabled = false;
        gameWin.SetActive(true);
    }

    public void Retry()
    {
        Scene loadedLevel = SceneManager.GetActiveScene ();
        SceneManager.LoadScene (loadedLevel.buildIndex);
    }
    
    void EndGame()
    {
        Player.SetActive(false);
        gameOver = true;
        gamedie.SetActive(true);
        Time.timeScale = 0f;
        battleTheme.volume = 0f;
        loseTheme.Play();
    }

    public void ContinueTo2()
    {
        SceneManager.LoadScene("Level 2");
        PlayerPrefs.SetInt("levelReached", 2);
    }

    public void ProgressTo2()
    {
        PlayerPrefs.SetInt("levelReached", 2);
    }
    public void ContinueTo3()
    {
        SceneManager.LoadScene("Level 3");
        PlayerPrefs.SetInt("levelReached", 3);
    }

    public void ProgressTo3()
    {
        PlayerPrefs.SetInt("levelReached", 3);
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                UnPause();
            }
        }
    }
}
