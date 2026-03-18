using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 5;

    private bool isDestroyed = false;
    private EnemyAbility[] abilities;

    void Start()
    {
        abilities = GetComponents<EnemyAbility>();

        foreach (var ability in abilities)
        {
            ability.OnSpawn();
        }
    }
    
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        foreach (var ability in abilities)
        {
            ability.OnTakeDamage(dmg);
        }

        if(hitPoints <= 0 && !isDestroyed)
        {
            foreach (var ability in abilities)
            {
                ability.OnDeath();
            }
            
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public void Initialize(EnemyData data)
    {
        hitPoints = data.hitPoints;
        currencyWorth = data.currencyWorth;
    }
}
