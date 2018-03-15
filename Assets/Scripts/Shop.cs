using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    /// <summary>
    /// Create new Buildmanger once
    /// </summary>
    public void Start()
    {
        buildManager = BuildManager.instance;
    }

    /// <summary>
    /// Set 'turretToBuild' to 'standardTurretPrefab'
    /// </summary>
	public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret has been selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    /// <summary>
    /// Set 'turretToBuild' to 'missileTurretPrefab'
    /// </summary>
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher has been selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}