﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    bool pause = false;

    public GameObject menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameReset()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void pauseSwitch()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
            menuCanvas.SetActive(false);
        }
        else
        {
            pause = true;
            Time.timeScale = 0;
            menuCanvas.SetActive(true);
        }
    }

    public void startMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
