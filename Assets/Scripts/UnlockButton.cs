using UnityEngine;
using TMPro;
using System;

public class UnlockButton : MonoBehaviour
{
    [SerializeField]private TowerInfo towerInfoScript;
    [SerializeField] private string towerType;
    [SerializeField] private int unlockCost = 100; //default price
    [SerializeField] private TMP_Text costText;
    [SerializeField] private MoneyDisplay MoneyDisplayScript;

    void Start()
    {
        UnlockText();
        costText.text = "Cost: " + System.Convert.ToString(unlockCost);
    }

    public void UnlockText()
    {
        TMP_Text unlockText = GetComponent<TMP_Text>();
        if (towerInfoScript.towers[towerType] == true)
        {
            unlockText.text = "Unlocked";
        }
        else
        {
            unlockText.text = "Unlock";
        }
    }

    public void UnlockButtonPress()
    {
        Debug.Log("Unlock button pressed for tower: " + towerType);
        // change text to unlocked
        if (MoneyDisplayScript.money >= unlockCost)
        {
            Debug.Log("Player has sufficient funds");
        }

        if (MoneyDisplayScript.money >= unlockCost &&  towerInfoScript.towers[towerType] != true)
        {
            Debug.Log("Player has sufficient funds");
            MoneyDisplayScript.SaveMoney(-unlockCost);
            towerInfoScript.towers[towerType] = true;
            towerInfoScript.SaveTowerData();
            UnlockText();
        }
    }


}
