using UnityEngine;

// Example
public class SplashAbility : TowerAbility // Derived from TowerAbility
{
    public float radius = 2f;
    public int damage = 1;

    public override void OnShoot(GameObject bullet, Transform target)
    {
        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.SetSplash(radius, damage);
        }
    }
}