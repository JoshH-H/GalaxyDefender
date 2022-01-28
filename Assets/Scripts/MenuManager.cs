using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject erase;

    private void Start()
    {
        levelSelect.SetActive(false);
    }

    public void openSelect()
    {
        levelSelect.SetActive(true);
    }

    public void level1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void level2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void eraseSave()
    {
        PlayerPrefs.DeleteAll();
        Scene loadedLevel = SceneManager.GetActiveScene ();
        SceneManager.LoadScene (loadedLevel.buildIndex);
    }
    
}
