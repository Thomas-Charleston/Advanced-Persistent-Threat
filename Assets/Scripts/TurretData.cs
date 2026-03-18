using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : ScriptableObject
{
    public string towerName;
    public int cost;

    [Header("Combat")]
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;

    [Header("Upgrade")]
    public int baseUpgradeCost;

    [Header("Visual")]
    public GameObject prefab;
    public GameObject previewPrefab;
}
