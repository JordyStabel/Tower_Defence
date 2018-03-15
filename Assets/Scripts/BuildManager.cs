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

    /// <summary>
    /// Build a turret on a selected Node
    /// </summary>
    /// <param name="node"></param>
    public void BuildTurretOnNode (Node node)
    {
        //Create new turret at the location of the current Node with no rotation
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        //Set the Node turret equal to the just created turret object
        node.turret = turret;
    }

    /// <summary>
    /// Set turretToBuild to input turretBlueprint
    /// </summary>
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
    }
}