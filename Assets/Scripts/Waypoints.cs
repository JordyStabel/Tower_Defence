using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

    public static Transform[] waypoints;
    //public static List<Transform> waypoints;

    /// <summary>
    /// Create list of waypoints
    /// </summary>
    void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}