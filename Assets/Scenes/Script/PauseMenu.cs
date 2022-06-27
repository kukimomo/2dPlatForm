﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause=false;
    public GameObject pauseMenuUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
          pauseMenuUI.SetActive(false);
          Time.timeScale=1.0f;
          GameIsPause=false;
    }
    public void Pause()
    {
          pauseMenuUI.SetActive(true);
          Time.timeScale=0.0f;
          GameIsPause=true;
    }
    public  void MainMenu()
    {
         GameIsPause=false;
         Time.timeScale=1.0f;
         SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
