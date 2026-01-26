using UnityEngine;
using TMPro;
using System;

public class UnlockButton : MonoBehaviour
{
    private TowerInfo towerInfoScript;
    [SerializeField] private string towerType;
    private PlayerMoney playerMoneyScript;
    [SerializeField] private int unlockCost = 100; //default price
    [SerializeField] private TMP_Text costText;

    void Start()
    {
        UnlockText(towerType);
        costText.text = "Cost: " + System.Convert.ToString(unlockCost);
    }

    public void UnlockText(string towerType)
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
            towerInfoScript.towers[towerType] = true;
            towerInfoScript.SaveTowerData();
            UnlockText(towerType);
        }

    }


}
