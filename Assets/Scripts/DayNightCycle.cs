using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public float speed = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Rotate around the center point of the scene, "forward" since the scene isn't correctly centered
        transform.RotateAround(Vector3.zero, Vector3.forward, (speed * Time.deltaTime));

        //Make the light shine towards the center point of the scene
        transform.LookAt(Vector3.zero);
	}
}