using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

    public static Transform[] waypointsPremade;
    public static List<Transform> waypointsRandom;

    /// <summary>
    /// Create list of waypoints
    /// </summary>
    void Awake()
    {
        waypointsPremade = new Transform[transform.childCount];
        for (int i = 0; i < waypointsPremade.Length; i++)
        {
            waypointsPremade[i] = transform.GetChild(i);
        }
    }
}