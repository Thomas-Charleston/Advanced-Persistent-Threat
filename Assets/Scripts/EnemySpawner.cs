using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Unity.VisualScripting;

[System.Serializable]
public class EnemyType
{
    public GameObject prefab;
    public EnemyData data;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    // [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private EnemyType[] enemyTypes;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 10f;
    [SerializeField] private float normalDataWait = 5f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float eps; // Enemies per second
    private float timeSinceLastSpawn;
    private float timeSinceLastNormalSpawn;
    private int  enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private int enemiesSpawned;


    void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    void Start()
    {
        timeSinceLastNormalSpawn = 0;
        StartCoroutine(StartWave());
    }

    void Update()
    {
        timeSinceLastNormalSpawn += Time.deltaTime;

        if (timeSinceLastNormalSpawn >= normalDataWait)
        {
            SpawnNormalData();
            timeSinceLastNormalSpawn = 0f;
        }

        if(!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;
        
        if (timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        enemiesSpawned = 0;
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
    }

    private void SpawnEnemy()
    {
        // GameObject prefabToSpawn = enemyPrefabs[0];
        // Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);

        EnemyType type = GetTypeToSpawn();
        
        GameObject obj = Instantiate(type.prefab, LevelManager.main.startPoint.position, Quaternion.identity);

        if (type.data != null)
        {
            obj.GetComponent<Health>().Initialize(type.data);
            obj.GetComponent<EnemyMovement>().Initialize(type.data);
        }
    }

    private void SpawnNormalData()
    {
        GameObject obj = Instantiate(enemyTypes[0].prefab, LevelManager.main.startPoint.position, Quaternion.identity);

        if (enemyTypes[0].data != null)
        {
            obj.GetComponent<EnemyMovement>().Initialize(enemyTypes[0].data);
        }
    }

    public EnemyType GetTypeToSpawn()
    {
        enemiesSpawned++;
        if ( enemiesSpawned <= 10 ) return enemyTypes[1]; // Values likely need adjusting
        else if ( enemiesSpawned <= 20) return enemyTypes[2];
        else
        {
            if (enemyTypes[3] == null) return enemyTypes[2]; // Checks if more enemy types exist
            return enemyTypes[3];
        }
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private void EnemyDestroyed()
    {
        enemiesAlive = Mathf.Max(0, enemiesAlive - 1);
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);
    }

}
