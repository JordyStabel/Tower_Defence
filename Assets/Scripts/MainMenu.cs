using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string startingLevel = "MainLevel";

	public void Play()
    {
        SceneManager.LoadScene(startingLevel);
    }

    public void Quit()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
}
