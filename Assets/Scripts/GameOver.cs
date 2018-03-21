using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text waveCount;

    void OnEnable()
    {
        waveCount.text = PlayerStats.wavesSurvived.ToString();
    }

    public void Retry()
    {
        //Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}