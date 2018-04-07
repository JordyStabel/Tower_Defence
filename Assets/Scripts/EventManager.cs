using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void DieEvent(int index);
    public static event DieEvent onEnemyDie;

    public delegate void SpawnEnemy(int index);
    public static event SpawnEnemy onEnemySpawn;

    public static void EnemyDeath(int index)
    {
        if (onEnemyDie != null)
        {
            onEnemyDie(index);
        }
    }

    public static void EnemySpawn(int index)
    {
        if (onEnemySpawn != null)
        {
            onEnemySpawn(index);
        }
    }
}