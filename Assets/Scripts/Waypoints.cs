using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

    public static List<Transform> waypoints;

    /// <summary>
    /// Create list of waypoints
    /// </summary>
    void Awake()
    {
        waypoints = new List<Transform>();
        for (int i = 0; i < waypoints.Count; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}