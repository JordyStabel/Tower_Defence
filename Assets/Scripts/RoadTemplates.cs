using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTemplates : MonoBehaviour {

    public GameObject[] bottomRoads;
    public GameObject[] topRoads;
    public GameObject[] leftRoads;
    public GameObject[] rightRoads;

    public GameObject endRoad;

    public float waitTime = 60f;
    private bool endCreated = false;

    public List<GameObject> roads;

    private GameObject roadToDestroy;
    private GameObject endNode;
    private Vector3 endPos;
    private GameObject lastNode;

    void Update()
    {
        if (waitTime <= 0)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                if (i == roads.Count - 1 && endCreated == false)
                {
                    roadToDestroy = roads[i];
                    lastNode = roads[i - 1];
                    endPos = roadToDestroy.transform.position;
                    roads.Remove(roadToDestroy);
                    Destroy(roadToDestroy);
                    Debug.Log(lastNode);
                    endNode = Instantiate(endRoad, endPos, Quaternion.identity);
                    roads.Add(endNode);
                    endNode.transform.LookAt(lastNode.transform.position);
                    endCreated = true;

                    //Set the array size equal to the number of roads created
                    Waypoints.waypointsPremade = new Transform[roads.Count];
                    for (int j = 0; i < Waypoints.waypointsPremade.Length; j++)
                    {
                        Transform pos = roads[j].transform;
                        Waypoints.waypointsPremade[j] = roads[j].transform;
                    }
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}