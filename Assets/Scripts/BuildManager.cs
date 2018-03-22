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

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public TurretUI turretUI;

    //Is there a turret selected?
    public bool isTurretSelected { get { return turretToBuild != null; } }

    //Has player enough money to build turret?
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    /// <summary>
    /// Set turretToBuild to input turretBlueprint
    /// </summary>
    public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
    {
        turretToBuild = turretBlueprint;
        DeselectNode();
    }

    /// <summary>
    /// Set selecetedNode to input node
    /// </summary>
    public void SelectNode(Node node)
    {
        //Hides UI when you double select a Turret
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}