using UnityEngine;
using UnityEngine.Accessibility;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float modifiersSpeed = 1f; // Default value, will be overridden by Modifiers script;
    [SerializeField] private int reputationDamage = 5;
    [SerializeField] private int dataDamage = 5;
    [SerializeField] Modifiers modifiers;

    private Transform target;
    private EnemyAbility[] abilities;
    private int pathIndex = 0;

    void Awake()
    {
        modifiers = Object.FindAnyObjectByType<Modifiers>();
    }

    void Start()
    {
        // Ensure LevelManager and path are set up properly
        if (LevelManager.main == null || LevelManager.main.path == null || LevelManager.main.path.Length == 0)
        {
            Debug.LogError("LevelManager or path not set up properly");
            Destroy(gameObject);
            return;
        }
        target = LevelManager.main.path[0];

        // Switch statement to set modifier speed based on ModifierButtonScript settings
        if (ModifierButtonScript.Instance != null)
        {
            modifiersSpeed = modifiers.speedType switch
            {
                "Twisted Pair" => 1f,
                "Coaxial" => 1.5f,
                "Fibre Optic" => 2f,
                _ => speed
            };
        }

        // Cache any attached abilities
        abilities = GetComponents<EnemyAbility>();
    }

    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) // Enemy reaches current target
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length) // Enemy reaches end of path
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);

                if (abilities != null && abilities.Length > 0)
                {
                    foreach (var ability in abilities)
                    {
                        if (ability != null)
                            ability.OnReachEnd();
                    }
                }

                LevelManager.main.DecreaseReputation(reputationDamage);
                DataValue.main.AddData(-dataDamage); // Negative because the method is adding
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * speed * modifiersSpeed; // Apply modifier speed to enemy movement
    }

    public void Initialize(EnemyData data)
    {
        speed = data.speed;
        reputationDamage = data.reputationDamage;
        dataDamage = data.dataDamage;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speed *= multiplier;
    }
}
