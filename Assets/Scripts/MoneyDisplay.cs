using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    public int money;
    private string savePath;
    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "money.json");

        if (File.Exists(savePath))
        {
            GetMoney();
        }
        else
        {
            money = 0; // start money
            SaveMoney(0);
        }
    }

    private void GetMoney()
    {
        try
        {
            string json = File.ReadAllText(savePath);
            PlayerMoney loadedMoney = JsonUtility.FromJson<PlayerMoney>(json);

            if (loadedMoney == null)
                return;

            money =  loadedMoney.money;
            UpdateDisplay();
        }
        catch
        {
            Debug.LogWarning("Save file corrupted. Resetting to defaults.");
            money = 0;
            SaveMoney(0);
        }
    }

    public void SaveMoney(int addSum) // parameter needed by other scripts to add or subtract money
    {
        PlayerMoney playerMoney = new PlayerMoney();
        playerMoney.money = money + addSum;
        string json = JsonUtility.ToJson(playerMoney);
        File.WriteAllText(savePath, json);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        moneyText.text = System.Convert.ToString(money);
    }
}
