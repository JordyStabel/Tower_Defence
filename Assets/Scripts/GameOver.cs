using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text waveCount;
    public string menuScene = "MainMenu";
    public SceneFader sceneFader;

    void OnEnable()
    {
        waveCount.text = PlayerStats.wavesSurvived.ToString();
    }

    public void Retry()
    {
        //Reload the current scene
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuScene);
    }
}