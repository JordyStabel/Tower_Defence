using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTemplates : MonoBehaviour {

    public GameObject[] bottomRoads;
    public GameObject[] topRoads;
    public GameObject[] leftRoads;
    public GameObject[] rightRoads;

    public GameObject endRoad;

    public float waitTime = .5f;
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
                    Destroy(roadToDestroy);
                    Debug.Log(lastNode);
                    endNode = Instantiate(endRoad, endPos, Quaternion.identity);
                    endNode.transform.LookAt(lastNode.transform.position);
                    endCreated = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}