using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Turret Tokens")]
    public Resource resource;

    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    /// <summary>
    /// Returns to correct position to place a turret on a Node
    /// </summary>
    /// <returns>Correct position</returns>
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    /// <summary>
    /// Sell a selected turret
    /// </summary>
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellValue();

        //Create a selleffect object
        GameObject sellEffect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        GameObject turretDestroyEffect = (GameObject)Instantiate(buildManager.destroyEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sellEffect, 5f);
        Destroy(turretDestroyEffect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    /// <summary>
    /// Build new turret if turret is selected & Node is available
    /// </summary>
    void OnMouseDown()
    {
        //Cancels action when there is a UI element over the Node
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Cancels action if there is already a turret on the Node
        if (turret != null)
        {
            //Select the node
            buildManager.SelectNode(this);
            return;
        }

        //Cancels action when there is no turret selected
        if (!buildManager.isTurretSelected)
            return;

        //Build a turret on current Node
        BuildTurret(buildManager.GetTurretToBuild());
    }

    /// <summary>
    /// Build a turret on a selected Node
    /// </summary>
    /// <param name="node"></param>
    void BuildTurret(TurretBlueprint blueprint)
    {
        //Checks if the player has enough money to build a turret
        if (PlayerStats.Money < blueprint.cost || resource.GetAmount() < 1)
            return;

        //Deduct the cost
        PlayerStats.Money -= blueprint.cost;

        //Deduct one turret token for each turret bought
        resource.Remove(1);

        //Create new turret at the location of the current Node with no rotation
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        //Set the Node turret equal to the just created turret object
        turret = _turret;

        turretBlueprint = blueprint;

        //Create a buildeffect object that can be destroyed again after 5 seconds
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        //Checks if the player has enough money to build a turret and enough turret tokens
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
            return;

        //Deduct the cost
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Create new turret at the location of the current Node with no rotation
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        //Set the Node turret equal to the just created turret object
        turret = _turret;

        //Create a buildeffect object that can be destroyed again after 5 seconds
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    /// <summary>
    /// Highlight Node
    /// </summary>
	void OnMouseEnter()
    {
        //Cancels action when there is a UI element over the Node
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Cancels action when there is no turret selected
        if (!buildManager.isTurretSelected)
            return;

        //Highlights Node with different color, depending on the amount of money
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    /// <summary>
    /// Deselect Node
    /// </summary>
    void OnMouseExit()
    {
        //Reset Node color to default color
        rend.material.color = startColor;
    }
}