using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completedLevelUI;

    void Start()
    {
        GameIsOver = false;
    }
	
	// Checks if there are enough lives left
	void Update () {

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
    }
}