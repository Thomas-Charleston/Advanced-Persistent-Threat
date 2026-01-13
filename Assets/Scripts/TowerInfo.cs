using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    string savePath;
    public Dictionary<string, bool> towers;

    Dictionary<string, bool> GetDefaultTowers()
    {
        return new Dictionary<string, bool>()
        {
            {"Antivirus", true},
            {"Backups", true},
            {"WebAppFirewall", true},
            {"DataEncryption", true},
            {"ZeroTrustGateway", true},
            {"BehaviouralAnalysisEngine", true},
            {"IDS", false},
            {"EndpointProtectionPlatform", false},
            {"RateLimiter", false},
            {"Sandbox", false},
            {"ThreatIntelFeed", false},
        };
    }

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "towers.json");

        if (File.Exists(savePath))
        {
            LoadTowerData();
        }
        else
        {
            towers = GetDefaultTowers();
            SaveTowerData();
        }
    }

    void LoadTowerData()
    {
        try
        {
            string json = File.ReadAllText(savePath);
            TowerData loadedData = JsonUtility.FromJson<TowerData>(json);

            // Start from defaults so new towers are added automatically
            towers = GetDefaultTowers();

            if (loadedData == null)
                return;

            for (int i = 0; i < loadedData.towerNames.Count; i++)
            {
                towers[loadedData.towerNames[i]] = loadedData.unlockedStates[i];
            }
        }
        catch
        {
            Debug.LogWarning("Save file corrupted. Resetting to defaults.");
            towers = GetDefaultTowers();
            SaveTowerData();
        }
    }

    void SaveTowerData()
    {
        TowerData data = new TowerData();

        foreach (var pair in towers)
        {
            data.towerNames.Add(pair.Key);
            data.unlockedStates.Add(pair.Value);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }
}