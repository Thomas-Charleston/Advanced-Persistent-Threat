using UnityEngine;
using UnityEngine.UI;

public class TowerBase : MonoBehaviour
{
    [Header("Upgrade")]
    [SerializeField] protected GameObject upgradeUI;
    [SerializeField] protected Button upgradeButton;
    [SerializeField] private int baseUpgradeCost;
    [SerializeField] protected GameObject rangeIndicator;

    public int BaseUpgradeCost
    {
        get => baseUpgradeCost;
        protected set => baseUpgradeCost = value;
    }

    protected int level = 1;

    protected virtual void Start()
    {
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(Upgrade);
    }

    public virtual void Upgrade()
    {
        if (CalculateCost() > LevelManager.main.currency) return;

        LevelManager.main.SpendCurrency(CalculateCost());
        level++;

        OnUpgrade();
    }

    public virtual void Initialize(GeneralTowerData data)
    {
        baseUpgradeCost = data.baseUpgradeCost;
    }

    protected virtual void OnUpgrade() { }

    protected int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(level, 0.8f));
    }

    public virtual void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
        if (rangeIndicator != null)
        {
            rangeIndicator.SetActive(true);
            
        }
    }

    public virtual void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        rangeIndicator.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }
}
