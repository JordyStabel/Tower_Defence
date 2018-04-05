using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour {

    public Text powerText;
    public Image powerBar;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameIsOver)
        {
            powerText.text = PlayerStats.power.ToString("n0") + "/" + PlayerStats.strPower.ToString();
            powerBar.fillAmount = PlayerStats.power / PlayerStats.strPower;
        }
    }
}