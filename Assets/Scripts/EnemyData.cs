using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemy")]
public class EnemyData : ScriptableObject // Enemy data asset
{
    public int hitPoints;
    public float speed;
    public int currencyWorth;
    public int reputationDamage;
    public int dataDamage;
}
