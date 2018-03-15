using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    /// <summary>
    /// Create new Buildmanager upon starting the game
    /// </summary>
    void Awake()
    {
        //Prevents multiple Buildmanagers
        if (instance != null)
        {
            Debug.Log("More than one build managers in the scene");
        }
        //Sets default Buildmanager to current Buildmanager
        instance = this;
    }

    //References to all Turrets
    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private GameObject turretToBuild;

    /// <summary>
    /// Returns the turret to build (current seleceted turret)
    /// </summary>
    /// <returns>Selected turret</returns>
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    /// <summary>
    /// Sets turret to build (current selected turret)
    /// </summary>
    /// <param name="turret"></param>
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}