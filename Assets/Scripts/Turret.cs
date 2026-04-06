using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Turret : TowerBase
{
    [Header("References")]
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TowerAbility[] abilities;
    [SerializeField] private int dmg;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float roationSpeed = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private EnemyTag canTarget;

    private float bpsBase; // Bullets per second
    private float targetingRangeBase;

    private float timeUntilFire;
    private Transform target;


    protected override void Start()
    {
        base.Start();

        bpsBase = fireRate;
        targetingRangeBase = targetingRange;

        abilities = GetComponents<TowerAbility>();
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            
            if(timeUntilFire >= 1f / fireRate)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        bulletScript.bulletDamage = dmg;

        bulletScript.SetAbilities(abilities);

        // Apply abilities
        foreach (var ability in abilities)
        {
            ability.OnShoot(bulletObj, target);
        }
    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) transform.position, 0f, enemyMask);

        foreach (var hit in hits)
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health == null) continue;

            if (health.HasTag(canTarget))
            {
                target = hit.transform;
                return;
            }
        }
        
        target = null; // Nothing found
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        rotationPoint.rotation = Quaternion.Slerp(rotationPoint.rotation, targetRotation, roationSpeed * Time.deltaTime); // Smoothly rotates the turret towards the target
    }

    public override void OpenUpgradeUI()
    {
        base.OpenUpgradeUI();
        DrawRangeCircle();
    }

    private void DrawRangeCircle()
    {
        int segments = 50;
        float angle = 0f;
        float angleStep = 360f / segments;
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * targetingRange;
            float y = Mathf.Sin(angle * Mathf.Deg2Rad) * targetingRange;
            points[i] = transform.position + new Vector3(x, y, 0);
            angle += angleStep;
        }
        LineRenderer lr = rangeIndicator.GetComponent<LineRenderer>();
        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }


    protected override void OnUpgrade()
    {
        fireRate = CalculateFireRate();
        targetingRange = CalculateRange();

        CloseUpgradeUI();
    }

    private float CalculateFireRate()
    {
        return bpsBase * Mathf.Pow(level, 0.3f);
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(level, 0.3f);
    }

    void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange); // Draws a circle in scene view to visualise the range
    }

    public override void Initialize(GeneralTowerData data)
    {
        base.Initialize(data);

        TurretData turretData = (TurretData)data;

        targetingRange = turretData.range;
        fireRate = turretData.fireRate;
        bulletPrefab = turretData.bulletPrefab;
        BaseUpgradeCost = turretData.baseUpgradeCost;
        dmg = turretData.dmg;

        bpsBase = fireRate;
        targetingRangeBase = targetingRange;
    }
}
