using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText;
	
	//Set the lives text equal to the amount of lives that the player has
	void Update () {
        livesText.text = PlayerStats.Lives + " LIVES";
	}
}