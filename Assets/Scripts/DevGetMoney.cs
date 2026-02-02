using UnityEngine;

public class DevGetMoney : MonoBehaviour
{
    [SerializeField] private MoneyDisplay MoneyDisplayScript;
    public void addMoney(int amount)
    {
        Debug.Log("addMoney called");
        MoneyDisplayScript.SaveMoney(amount);
    }
}
