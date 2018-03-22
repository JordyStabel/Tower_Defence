using UnityEngine;

public class TurretUI : MonoBehaviour {

    public GameObject UI;
    private Node target;

    public void SetTarget(Node _target)
    {
        UI.SetActive(true);
        target = _target;

        transform.position = target.GetBuildPosition();
    }

    //Disable the turretUI element
    public void Hide()
    {
        UI.SetActive(false);
    }
}