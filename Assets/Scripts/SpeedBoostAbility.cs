using UnityEngine;

public class SpeedBoostAbility : EnemyAbility
{
    // Example ability
    [SerializeField] private float multiplier = 2f;

    public override void OnSpawn()
    {
        EnemyMovement move = GetComponent<EnemyMovement>();
        if (move != null)
        {
            move.SetSpeedMultiplier(multiplier);
        }
    }
}
