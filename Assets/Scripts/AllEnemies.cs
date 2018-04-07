using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemies : MonoBehaviour {

    [SerializeField]
    private static List<GameObject> allEnemies;

    public void addEnemy(GameObject enemy)
    {
        allEnemies.Add(enemy);
    }

    public void removeEnemy(GameObject enemy)
    {
        allEnemies.Remove(enemy);
    }

    public List<GameObject> getAllEnemies()
    {
        return allEnemies;
    }
}