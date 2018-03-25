using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelecter : MonoBehaviour {

    public SceneFader sceneFader;

	public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}