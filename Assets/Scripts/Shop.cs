﻿using UnityEngine;

public class Shop : MonoBehaviour {

    //Referces turretBlueprints for all turrets
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint miniGun;
    public TurretBlueprint windMill;

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

    /// <summary>
    /// Select 'laserBeamerPrefab'
    /// </summary>
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer has been selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    /// <summary>
    /// Select 'minigunTurret'
    /// </summary>
    public void SelectMinigunTurret()
    {
        Debug.Log("Minigun Turret has been selected");
        buildManager.SelectTurretToBuild(miniGun);
    }

    /// <summary>
    /// Select 'windMillTurret'
    /// </summary>
    public void SelectWindMillTurret()
    {
        Debug.Log("Windmill has been selected");
        buildManager.SelectTurretToBuild(windMill);
    }
}