using UnityEngine;

[CreateAssetMenu(fileName = "TurretData", menuName = "Scriptable Objects/TurretData")]
public class TurretData : GeneralTowerData
{
    [Header("Combat")]
    public float range;
    public float fireRate;
    public GameObject bulletPrefab;
    public int dmg;
}
