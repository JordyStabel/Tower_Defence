using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject UI;

	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }

	}

    public void TogglePauseMenu()
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

    public void Retry()
    {
        //Reload the current scene
        TogglePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu!");
    }
}