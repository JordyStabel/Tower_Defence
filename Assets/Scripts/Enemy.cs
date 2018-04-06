using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    public static float startHealth = 100f;
    public static int startKillReward = 1;

    public float speed;
    public float health;
    public int killReward;

    float red = 0;
    float maxRed = 1;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;
    public Text healthAmountText;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        killReward = startKillReward;
        healthAmountText.text = health.ToString("n0");
    }

    /// <summary>
    /// Handles taking damage, input is amount of damage taken
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        health -= amount;

        #region Color change effect for enemies, self made
        //Change color
        float percentageHit = (amount / health);

        red = red + (maxRed * percentageHit);
        maxRed -= (maxRed * percentageHit);

        //Go from 'Enemy blue' to pinkish purple, depending on the health
        Color newColor = new Color(red, (1 - red), 1, 1);
        gameObject.GetComponent<Renderer>().material.color = newColor;
        #endregion

        //Change healthbar fill amount
        healthBar.fillAmount = health / startHealth;

        //Change healthAmountText
        healthAmountText.text = health.ToString("n0");

        if (health <= 0 && !isDead)
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
        isDead = true;

        PlayerStats.Money += killReward;

        //Create new death effect object at location of the enemy
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemyCount--;

        Destroy(gameObject);
    }
}