using UnityEngine;
using TMPro;
using System;

public class UnlockButton : MonoBehaviour
{
    [SerializeField]private TowerInfo towerInfoScript;
    [SerializeField] private string towerType;
    [SerializeField] private PlayerMoney playerMoneyScript;
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
        // change text to unlocked
        if (playerMoneyScript.money >= unlockCost &&  towerInfoScript.towers[towerType] != true)
        {
            MoneyDisplayScript.SaveMoney(-unlockCost);
            towerInfoScript.towers[towerType] = true;
            towerInfoScript.SaveTowerData();
            UnlockText();
        }
    }


}
