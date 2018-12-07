﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Constants and Variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update(){
        //Pausing game with Esc key
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    //Method which unpauses the game
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Method which pauses the game
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Method which quits the level
    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }
}