using UnityEditor;
using UnityEngine;

public abstract class TowerAbility : MonoBehaviour // Super class
{
    public virtual void OnShoot(GameObject bullet, Transform target) {} // Can be overridden
    public virtual void OnHit(GameObject enemy, ref float damage) {}
    public virtual void OnPlace() {}

}