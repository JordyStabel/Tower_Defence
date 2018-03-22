using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    public static float startHealth = 100f;
    public static int startKillReward = 1;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;
    [HideInInspector]
    public int killReward;

    float red = 0;
    float maxRed = 1;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        killReward = startKillReward;
    }

    /// <summary>
    /// Handles taking damage, input is amount of damage taken
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        //Change color
        float percentageHit = (amount / health);

        red = red + (maxRed * percentageHit);
        maxRed -= (maxRed * percentageHit);

        //Go from 'Enemy blue' to pinkish purple, depending on the health
        Color newColor = new Color(red, (1 - red), 1, 1);
        gameObject.GetComponent<Renderer>().material.color = newColor;

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