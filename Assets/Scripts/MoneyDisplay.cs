using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    public int money;
    private string savePath;
    private static MoneyDisplay instance;
    public static MoneyDisplay Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null) // Singleton logic to be accessed in other scenes
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        savePath = Path.Combine(Application.persistentDataPath, "money.json");

        if (File.Exists(savePath))
        {
            GetMoney();
            Debug.Log("Existing money found in files");
        }
        else // player hasn't played before
        {
            money = 0; // start money
            SaveMoney(0);
            Debug.Log("No existing money found, starting at 0");
        }
    }

    private void GetMoney()
    {
        try
        {
            string json = File.ReadAllText(savePath);
            PlayerMoney loadedMoney = JsonUtility.FromJson<PlayerMoney>(json);

            if (loadedMoney == null) // Player has no money
                return;

            money =  loadedMoney.money;
            UpdateDisplay();
            Debug.Log("Successfully loaded money from file.");
        }
        catch
        {
            Debug.LogWarning("Save file corrupted. Resetting to defaults.");
            money = 0;
            SaveMoney(0);
            Debug.Log("Could not load money from file, resetting to 0.");
        }
    }

    public void SaveMoney(int addSum) // parameter needed by other scripts to add or subtract money
    {
        Debug.Log("Saving money to file with change of: " + addSum);
        money += addSum;
        PlayerMoney playerMoney = new PlayerMoney();
        playerMoney.money = money;
        string json = JsonUtility.ToJson(playerMoney);
        File.WriteAllText(savePath, json);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        Debug.Log("Updating balance display");
        moneyText.text = System.Convert.ToString(money);
    }
}
