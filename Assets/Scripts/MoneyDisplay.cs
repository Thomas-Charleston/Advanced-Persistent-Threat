using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text moneyText;
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
            SaveMoney();
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
        }
        catch
        {
            Debug.LogWarning("Save file corrupted. Resetting to defaults.");
            money = 0;
            SaveMoney();
        }
    }

    private void SaveMoney()
    {
        PlayerMoney playerMoney = new PlayerMoney();
        playerMoney.money = money;
        string json = JsonUtility.ToJson(playerMoney);
        File.WriteAllText(savePath, json);
        moneyText.text = System.Convert.ToString(money);
    }
}
