using UnityEngine;

public abstract class TowerAbility : MonoBehaviour // Super class
{
    public virtual void OnShoot(GameObject bullet, Transform target) // Can be overridden
    {
        
    }
}