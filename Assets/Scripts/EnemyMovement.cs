using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    /// <summary>
    /// Set first waypoint for enemy object
    /// </summary>
    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.waypoints[0];
    }

    /// <summary>
    /// Movement of the enemy
    /// </summary>
    void Update()
    {
        //Direction object needs to move in is equal to posistion of waypoint minus the current position of the enemy
        Vector3 direction = target.position - transform.position;
        //Moves the object forward
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        //Sets new waypoint/target when in range of the current target/waypoint (0.2f margin to make it smoove)
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    /// <summary>
    /// Switch enemy target/waypoint
    /// </summary>
    void GetNextWaypoint()
    {
        //Destroy the object when it reaches the end of the map (no more waypoints)
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }

        //Move on the next waypoint
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    //Decrease the lives and destroy the object
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}