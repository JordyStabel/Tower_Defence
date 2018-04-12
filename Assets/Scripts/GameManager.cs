using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completedLevelUI;

    private bool gameRunning = true;
    private float second = 2.5f;

    void Start()
    {
        GameIsOver = false;
    }
	
	// Checks if there are enough lives left
	void Update () {

        if (!gameRunning)
        {
            second -= Time.deltaTime;
        }

        Toggle();

        //If game has ended return
        if (GameIsOver)
            return;

        //Else deduct lives
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    //Ends the game
    private void EndGame()
    {
        //Game over plus UI screen
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void CompleteLevel()
    {
        GameIsOver = true;
        completedLevelUI.SetActive(true);
        Toggle();
    }

    public void Continue()
    {
        completedLevelUI.SetActive(false);
        GameIsOver = false;
        Toggle();
    }

    //Toggle time on and off
    public void Toggle()
    {
        if (completedLevelUI.activeSelf)
        {
            gameRunning = false;
            if (second <= 0)
            {
                Time.timeScale = 0f;
            }
        }
        else if (!GameIsOver && completedLevelUI.activeSelf)
        {
            Time.timeScale = 1f;
            gameRunning = true;
            second = 2.5f;
        }
    }
}