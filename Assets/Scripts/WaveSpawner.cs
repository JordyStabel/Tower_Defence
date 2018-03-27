using UnityEngine;
using System.Collections;
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
    }

    /// <summary>
    /// Create new enemy object at the starting point
    /// </summary>
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}