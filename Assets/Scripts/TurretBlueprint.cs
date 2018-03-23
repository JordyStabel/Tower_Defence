using UnityEngine;


/// <summary>
/// Create a default blueprint for turrets. 'System.Serializable' needed for it to showup in Unity
/// </summary>
[System.Serializable]
public class TurretBlueprint
{
    //Requires turret prefab & cost
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellValue()
    {
        return cost / 2;
    }
}