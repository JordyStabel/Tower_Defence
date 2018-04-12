using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog dialog;

    private bool isTriggered = false;

    public void TriggerDialog()
    {
        if (!isTriggered)
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
            isTriggered = true;
        }
    }
}