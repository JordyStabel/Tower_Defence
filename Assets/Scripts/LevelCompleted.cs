using UnityEngine;

public class LevelCompleted : MonoBehaviour {

    public string menuScene = "MainMenu";

    public string nextLevel = "Level_2";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Menu()
    {
        //Reload the current scene
        sceneFader.FadeTo(menuScene);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}