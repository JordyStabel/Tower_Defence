using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemyCount = 0;
    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 0;
    private int waveMultiplier = 1;

    public GameManager gameManager;

    public List<Enemy> allEnemies = new List<Enemy>();

    private int index = 0;

    void Start()
    {
        //This fixes a bug where the enemyCount whould still be >0 and thus not spawn any enemies
        enemyCount = 0;

        EventManager.onEnemyDie += deleteEnemy;
    }

    private void OnDisable()
    {
        EventManager.onEnemyDie -= deleteEnemy;
    }

    /// <summary>
    /// Create new waves of enemies
    /// </summary>
    void Update()
    {
        //Don't spawn enemies before all previous enemies are destroyed
        if (enemyCount > 0)
            return;

        if (waveNumber == waves.Length)
        {
            waveNumber = 0;
            waveMultiplier++;
            gameManager.CompleteLevel();
        }

        //Only create a wave if the timer <= 0
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        //Decrease countDown with the time past between frames
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        //Set timer text equal to the countDown
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    /// <summary>
    /// Create enum of spawnwaves
    /// </summary>
    /// <returns>current waveNumber</returns>
    IEnumerator SpawnWave()
    {
        //Selects a wave depending on the wavenumber
        Wave wave = waves[waveNumber];

        enemyCount = wave.enemyCount;

        //Spawn the same amoun of enemies as the current waveNumber
        for (int i = 0; i < (wave.enemyCount * waveMultiplier); i++)
        {
            SpawnEnemy(wave.enemy);
            //Wait 0.5 between spawning (so they aren't on top of each other)
            yield return new WaitForSeconds(1f / wave.rate);
        }

        //Increase healthpool by x % every wave
        Enemy.startHealth = (Enemy.startHealth * 1.10f);

        //Increase the killreward for killing a enemy each wave
        Enemy.startKillReward++;

        PlayerStats.wavesSurvived++;

        waveNumber++;
        index = 0;
    }

    /// <summary>
    /// Create new enemy object at the starting point
    /// </summary>
    void SpawnEnemy(Enemy enemy)
    {
        EventManager.EnemySpawn(this.index);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemy.index = index;
        allEnemies.Add(enemy);
        index++;
    }

    void deleteEnemy(int index)
    {
        allEnemies.RemoveAll(e => e.index == index);
    }
}