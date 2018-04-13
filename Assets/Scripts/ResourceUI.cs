using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{
    public Resource resource;
    public Text uiText;

    //Subscribe to event
    private void OnEnable()
    {
        resource.onChange += resourceChanged;
    }

    //Unsubscribe to event
    private void OnDisable()
    {
        resource.onChange -= resourceChanged;
    }

    private void resourceChanged()
    {
        uiText.text = "Tokens: " + resource.GetAmount();
    }
}