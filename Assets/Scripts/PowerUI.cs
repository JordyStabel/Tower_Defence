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
            powerText.text = "POWER: " + PlayerStats.power.ToString("n0") + "/" + PlayerStats.strPower.ToString("n0");
            powerBar.fillAmount = PlayerStats.power / PlayerStats.strPower;
        }
    }
}