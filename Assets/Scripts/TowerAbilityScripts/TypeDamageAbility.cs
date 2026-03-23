using UnityEngine;

public class TypeDamageAbility : TowerAbility
{
    public EnemyTag effectiveAgainst;
    public float multiplier = 2f;
    
    public override void OnHit(GameObject enemy, ref float damage)
    {
        Health health = enemy.GetComponent<Health>();
        if (health == null) return;

        if (health.HasTag(effectiveAgainst))
        {
            damage *= multiplier;
        }
    }
}