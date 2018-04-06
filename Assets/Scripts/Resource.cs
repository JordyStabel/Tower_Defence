using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour {

    [SerializeField] private float amount;
    public float startAmount;

    public UnityEvent OnValueChanged = new UnityEvent();

    void Awake()
    {
        amount = startAmount;
    }

    public void AddAmount(float value)
    {
        amount += value;
        updateUI();
    }

    public void RemoveAmount(float value)
    {
        amount -= value;
        updateUI();
    }

    public bool CanAfford(float cost)
    {
        return amount >= cost;
    }

    public float getAmount()
    {
        return amount;
    }

    void updateUI()
    {
        OnValueChanged.Invoke();
    }
}