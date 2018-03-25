using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startingLevel = "Level_1";
    public SceneFader sceneFader;

	public void Play()
    {
        sceneFader.FadeTo(startingLevel);
    }

    public void Quit()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}