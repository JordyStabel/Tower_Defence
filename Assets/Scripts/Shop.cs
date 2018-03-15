﻿using UnityEngine;

public class Shop : MonoBehaviour {

    //Referces turretBlueprints for all turrets
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    BuildManager buildManager;

    /// <summary>
    /// Create new Buildmanger once
    /// </summary>
    public void Start()
    {
        buildManager = BuildManager.instance;
    }

    /// <summary>
    /// Select 'standardTurretPrefab'
    /// </summary>
	public void SelectStandardTurret()
    {
        Debug.Log("Standard turret has been selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    /// <summary>
    /// Select 'missileTurretPrefab'
    /// </summary>
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher has been selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}