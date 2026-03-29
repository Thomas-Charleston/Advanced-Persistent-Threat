using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    
    public GameObject towerObj;
    public Turret turret;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
        {
            sr.color = hoverColor;
        }

    private void OnMouseExit()
        {
            sr.color = startColor;
        }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (towerObj != null)
        {
            TowerBase existingTower = towerObj.GetComponent<TowerBase>();
            if (existingTower != null)
            {
                existingTower.OpenUpgradeUI();
            }
            return;
        }

        GeneralTowerData towerToBuild = BuildManager.main.GetSelectedTower();
        if (towerToBuild == null) return;

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("Not enough currency to build that tower");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

        TowerBase tower = towerObj.GetComponent<TowerBase>();

        if (tower != null)
        {
            tower.Initialize(towerToBuild);
        }
        else
        {
            Debug.LogError("TowerBase missing on prefab");
        }

        BuildManager.main.SetSelectedTower(-1);
    }

}
