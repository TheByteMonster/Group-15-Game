﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour {
    public void playGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void resumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
}
    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
