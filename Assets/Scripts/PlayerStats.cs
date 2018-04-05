using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    //Static because it will carry over to different scenes
    public static int Money;
    public int startMoney = 400;

    public static float power;
    public float startPower = 100f;
    public static float strPower;

    public static int Lives;
    public int startLives = 20;

    public static int wavesSurvived;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        power = startPower;
        strPower = startPower;
        wavesSurvived = 0;
    }


}