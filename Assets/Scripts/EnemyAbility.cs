using UnityEngine;

public abstract class EnemyAbility : MonoBehaviour
{
    public virtual void OnSpawn() {}
    public virtual void OnTakeDamage(int damage) {}
    public virtual void OnDeath() {}
    public virtual void OnReachEnd() {}
}
