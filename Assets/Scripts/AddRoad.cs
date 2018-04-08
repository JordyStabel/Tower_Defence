using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoad : MonoBehaviour {

    private RoadTemplates roadTemplates;

	void Start ()
    {
        roadTemplates = GameObject.FindGameObjectWithTag("Roads").GetComponent<RoadTemplates>();
        roadTemplates.roads.Add(this.gameObject);
        roadTemplates.waitTime = .5f;
        Debug.Log(roadTemplates.waitTime);
	}
}