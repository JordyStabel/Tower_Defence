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

    private TurretBlueprint turretToBuild;

    //Is there a turret selected?
    public bool isTurretSelected { get { return turretToBuild != null; } }

    //Has player enough money to build turret?
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    /// <summary>
    /// Build a turret on a selected Node
    /// </summary>
    /// <param name="node"></param>
    public void BuildTurretOnNode (Node node)
    {
        //Checks if the player has enough money to build a turret
        if (PlayerStats.Money < turretToBuild.cost)
        {
            //TODO: Add a visual component to alert the player
            Debug.Log("Not enough money to build turret");
            return;
        }

        //Deduct the cost
        PlayerStats.Money -= turretToBuild.cost;

        //Create new turret at the location of the current Node with no rotation
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        //Set the Node turret equal to the just created turret object
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    /// <summary>
    /// Set turretToBuild to input turretBlueprint
    /// </summary>
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }
}