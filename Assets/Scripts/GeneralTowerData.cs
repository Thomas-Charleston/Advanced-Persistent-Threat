using UnityEngine;

public class GeneralTowerData : ScriptableObject
{
    public string towerName;
    public int cost;
    public int baseUpgradeCost;

    [Header("Visual")]
    public GameObject previewPrefab;
    public GameObject prefab;
}
