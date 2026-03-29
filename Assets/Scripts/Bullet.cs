using UnityEngine;
using UnityEngine.Accessibility;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 10f;
    
    public int bulletDamage = 1;

    private Transform target;
    private TowerAbility[] abilities;

    public void SetAbilities(TowerAbility[] sourceAbilities)
    {
        abilities = sourceAbilities;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        if(!target || !target.gameObject.activeInHierarchy) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();
        if (health == null) return;

        float damage = bulletDamage;

        foreach (var ability in abilities)
        {
            ability.OnHit(other.gameObject, ref damage);
        }

        health.TakeDamage(Mathf.RoundToInt(damage));
        
        Destroy(gameObject);
    }

    public void SetSplash(float radius, int damage) { Debug.Log("Splash bullet"); }

}