using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 2f;

    private Transform target;
    private int pathIndex = 0;

    void Start()
    {
        target = LevelManager.main.path[0];
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

        rb.linearVelocity = direction * speed;
    }
}
