using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour {

    public float powerProduction = 5f;

    void Start()
    {
        //Give each windmill a random rotation around the y axis
        var euler = transform.eulerAngles;
        euler.y = Random.Range(0, -180);
        transform.eulerAngles = euler; ;
    }

	void Update () {

        if (!GameManager.GameIsOver && PlayerStats.power <= PlayerStats.strPower)
        {
            PlayerStats.power += (powerProduction * Time.deltaTime);
        }
	}
}