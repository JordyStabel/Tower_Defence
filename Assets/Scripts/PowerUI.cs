using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour {

    public Text powerText;
    public Image powerBar;

    public GameObject powerbarEffect;
    public Transform bottom;

    private Vector3 pos;
    GameObject effect;

    private void Start()
    {
        pos = bottom.transform.position;
        effect = (GameObject)Instantiate(powerbarEffect, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameIsOver)
        {
            pos = bottom.transform.position;
            pos.z += (79 * powerBar.fillAmount);
            effect.transform.position = pos;
            powerText.text = "POWER: " + PlayerStats.power.ToString("n0") + "/" + PlayerStats.strPower.ToString("n0");
            powerBar.fillAmount = PlayerStats.power / PlayerStats.strPower;
        }
    }
}