using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalDataLvl2 : MonoBehaviour
{
    public GameObject Player;
   // public GameObject Manager;
    static public int lives2 = 3;
    static public bool paused = false;
    static public bool gameOver = false;
    public GameObject[] hearts;
    //public GameObject[] shields;
    public GameObject pauseMenu;
    public GameObject gameWin;
    public GameObject gamedie;
    public AudioSource battleTheme;
    public AudioSource loseTheme;


    private void Awake()
    {
        Player.SetActive(true);
        gameOver = false;
        gameWin.SetActive(false);
        gamedie.SetActive(false);
        lives2 = 3;
        UpdateLives2();
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
       // Manager.GetComponent<WaveSpawn>().enabled = true;
    }
    public void UpdateLives2()
    {
        for(int i = 0; i < hearts.Length;i++)
        {
            if (lives2 > i)
            {
                hearts[i].SetActive(false);
                //shields[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(true);
                //shields[i].SetActive(false);
            }
        }

        if(lives2 <= 0)
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
        Player.GetComponent<PlayerMoveL2>().enabled = false;
       // Manager.GetComponent<WaveSpawn>().enabled = false;
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

    /*public void ContinueTo3()
    {
        SceneManager.LoadScene("Level 3");
        PlayerPrefs.SetInt("levelReached", 3);
    }*/
    
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
