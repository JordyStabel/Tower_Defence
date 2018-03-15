using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] waypoints;

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