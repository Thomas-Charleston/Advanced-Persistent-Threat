using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [UnitHeaderInspectable("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;

    void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }
}
