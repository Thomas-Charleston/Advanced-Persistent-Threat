using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 1f;

    private Transform target;
    private int pathIndex = 0;

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
            speed = ModifierButtonScript.Instance.speedType switch
            {
                "Twisted Pair" => 1f,
                "Coaxial" => 1.5f,
                "Fibre Optic" => 2f,
                _ => speed
            };
        }
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

        float effectiveSpeed = speed * GameNav.Instance.activeFf;
        rb.linearVelocity = direction * effectiveSpeed;
    }
}
