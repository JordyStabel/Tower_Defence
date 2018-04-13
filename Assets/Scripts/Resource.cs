using UnityEngine;

public class Resource : MonoBehaviour
{
    public int startAmount;
    [SerializeField]
    private int amount;

    public delegate void ChangeAmount();
    public event ChangeAmount onChange;

    private void Start()
    {
        amount = startAmount;
        if (onChange != null) onChange();
    }

    public int GetAmount()
    {
        return amount;
    }

    public void Remove(int _amount)
    {
        Debug.Log("Been here");
        amount -= _amount;
        if (onChange != null) onChange();
    }

    public void Add(int _amount)
    {
        amount += +amount;
        if (onChange != null) onChange();
    }
}