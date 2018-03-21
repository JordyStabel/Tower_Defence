using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int killReward = 25;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    /// <summary>
    /// Handles taking damage, input is amount of damage taken
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Slows down the enemy by the amount given
    /// </summary>
    /// <param name="amount"></param>
    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
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
}