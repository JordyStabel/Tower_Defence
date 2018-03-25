using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject UI;
    public string mainMenu = "MainMenu";
    public SceneFader sceneFader;

    private bool isSlowMotion = false;

	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
        //Slowdown time --> Just for testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleSlowMotion();
        }
    }

    //Toggle time on and off
    public void Toggle()
    {
        //Flip the isActive state of the UI object
        UI.SetActive(!UI.activeSelf);

        //Actually pause and unpause the game
        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    //Toggle time on and off
    public void ToggleSlowMotion()
    {
        //Flip the isSlowMotion bool
        isSlowMotion = !isSlowMotion;

        //Actually pause and unpause the game
        if (isSlowMotion)
        {
            Time.timeScale = 0.35f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        //Reload the current scene
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(mainMenu);
    }
}