using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 1;

    /// <summary>
    /// Create new waves of enemies
    /// </summary>
    void Update()
    {
        //Only create a wave if the timer <= 0
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        //Decrease countDown with the time past between frames
        countDown -= Time.deltaTime;

        //Set timer text to a rounded number of the countDown
        waveCountdownText.text = Mathf.Round(countDown).ToString();
    }

    /// <summary>
    /// Create enum of spawnwaves
    /// </summary>
    /// <returns>current waveNumber</returns>
    IEnumerator SpawnWave()
    {
        //Spawn the same amoun of enemies as the current waveNumber
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            //Wait 0.5 between spawning (so they aren't on top of each other)
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    /// <summary>
    /// Create new enemy object at the starting point
    /// </summary>
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}