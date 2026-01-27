using UnityEngine;

public class ShowTowerInfo : MonoBehaviour
{
    public void OpenTowerInfo(GameObject towerInfoPanel)
    {
        towerInfoPanel.SetActive(true);
    }

    public void CloseTowerInfo(GameObject towerInfoPanel)
    {
        towerInfoPanel.SetActive(false);
    }
}
