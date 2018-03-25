using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesSurvived : MonoBehaviour {

    public Text waveCount;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    
    //Display waves survived with counting up animation
    IEnumerator AnimateText()
    {
        waveCount.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(0.75f);

        while (wave < PlayerStats.wavesSurvived)
        {
            wave++;
            waveCount.text = wave.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}