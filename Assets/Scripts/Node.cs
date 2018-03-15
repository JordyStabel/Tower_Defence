using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

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
    /// Build new turret if turret is selected & Node is available
    /// </summary>
    void OnMouseDown()
    {
        //Cancels action when there is a UI element over the Node
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        //Cancels action when there is no turret selected
        if (buildManager.GetTurretToBuild() == null)
            return;

        //Cancels action if there is already a turret on the Node
        if (turret != null)
        {
            Debug.Log("There is already a turret on the node.");
            return;
        }
        else
        {
            //Builds turret
            GameObject turretToBuild = buildManager.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
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
        if (buildManager.GetTurretToBuild() == null)
            return;

        //Highlights Node with different color
        rend.material.color = hoverColor;
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