using UnityEngine;
using TMPro;
using System;

public class UnlockButton : MonoBehaviour
{
    private TowerInfo towerInfoScript;
    [SerializeField] private string towerType;

    void Start()
    {
        UnlockText(towerType);
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
        towerInfoScript.towers[towerType] = true;
        towerInfoScript.SaveTowerData();
    }


}
