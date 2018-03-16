using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isGameEnded = false;
	
	// Checks if there are enough lives left
	void Update () {

        //If game has ended return
        if (isGameEnded)
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
        Debug.Log("Game Over!");
        isGameEnded = true;
        //TODO: Restart the game or something else
    }
}