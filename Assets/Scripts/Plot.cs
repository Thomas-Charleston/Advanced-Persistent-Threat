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
        if (EventSystem.current.IsPointerOverGameObject()) return; // Cannot interact with the plot if the mouse is currently hovering over a UI element

        if (towerObj != null)
        {
            turret.OpenUpgradeUI();
            return;
        }

        if (BuildManager.main.GetSelectedTower() == null) return; // No tower selected to build

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("Not enough currency to build that tower");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
        BuildManager.main.SetSelectedTower(-1); // Deselect tower after building
    }

}
