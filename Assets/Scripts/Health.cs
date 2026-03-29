using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 5;

    private bool isDestroyed = false;
    private EnemyAbility[] abilities;
    private EnemyData data;
    // private float repDamping;
    // private TowerAbility[] towerAbilities;

    void Start()
    {
        // repDamping = 1f;

        // towerAbilities = GetComponents<TowerAbility>();

        // foreach (var )

        abilities = GetComponents<EnemyAbility>();

        foreach (var ability in abilities)
        {
            ability.OnSpawn();
        }
    }
    
    public void TakeDamage(int dmg)
    {
        hitPoints -= Mathf.RoundToInt(dmg ); //* repDamping

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

    public void Initialize(EnemyData d)
    {
        hitPoints = d.hitPoints;
        currencyWorth = d.currencyWorth;
        data = d;
    }

    public bool HasTag(EnemyTag tag)
    {
        return (data.tags & tag) != 0;
    }
}
