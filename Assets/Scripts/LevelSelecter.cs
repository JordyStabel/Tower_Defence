using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour {

    public SceneFader sceneFader;

    public Button[] levelButtons;
    
    void Start()
    {
        //Finds the highest level a player has reached or 1 as default (first time playing)
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

	public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}