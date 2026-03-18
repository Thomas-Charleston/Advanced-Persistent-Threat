using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject rangeIndicator;
    [SerializeField] private TowerAbility[] abilities;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float roationSpeed = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int baseUpgradeCost = 10;

    private float bpsBase; // Bullets per second
    private float targetingRangeBase;

    private float timeUntilFire;
    private Transform target;

    private int level = 1;

    void Start()
    {
        bpsBase = fireRate;
        targetingRangeBase = targetingRange;

        abilities = GetComponents<TowerAbility>();

        upgradeButton.onClick.AddListener(Upgrade);
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

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        rotationPoint.rotation = Quaternion.Slerp(rotationPoint.rotation, targetRotation, roationSpeed * Time.deltaTime); // Smoothly rotates the turret towards the target
    }

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
        if (rangeIndicator != null)
        {
            rangeIndicator.SetActive(true);
            DrawRangeCircle();
        }
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

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        rangeIndicator.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }

    public void Upgrade()
    {
        if (CalculateCost() > LevelManager.main.currency) return;

        LevelManager.main.SpendCurrency(CalculateCost());

        level++;

        fireRate = CalculateFireRate();
        targetingRange = CalculateRange();

        CloseUpgradeUI();
    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateFireRate()
    {
        return bpsBase * Mathf.Pow(level, 0.6f);
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(level, 0.4f);
    }

    void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange); // Draws a circle in scene view to visualise the range
    }

    public void Initialize(TurretData data)
    {
        targetingRange = data.range;
        fireRate = data.fireRate;
        bulletPrefab = data.bulletPrefab;
        baseUpgradeCost = data.baseUpgradeCost;

        bpsBase = fireRate;
        targetingRangeBase = targetingRange;
    }
}
