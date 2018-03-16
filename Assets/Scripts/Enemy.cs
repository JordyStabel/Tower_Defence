using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    public int killReward = 25;

    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    /// <summary>
    /// Set first waypoint for enemy object
    /// </summary>
    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    /// <summary>
    /// Handles taking damage, input is amount of damage taken
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Handles dying of enemies
    /// </summary>
    void Die()
    {
        PlayerStats.Money += killReward;

        //Create new death effect object at location of the enemy
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    /// <summary>
    /// Movement of the enemy
    /// </summary>
    void Update()
    {
        //Direction object needs to move in is equal to posistion of waypoint minus the current position of the enemy
        Vector3 direction = target.position - transform.position;
        //Moves the object forward
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        //Sets new waypoint/target when in range of the current target/waypoint (0.2f margin to make it smoove)
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
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
        PlayerStats.Lives --;
        Destroy(gameObject);
    }
}