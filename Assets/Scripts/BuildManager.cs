using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers;

    [Header("Attributes")]
    [SerializeField] private GameObject exitSelect;

    private int selectedTower = -1;
    private bool isPlacingTower = false;
    private GameObject preview;

    void Awake()
    {
        main = this;
    }

    void Update()
    {
        if (isPlacingTower)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            preview.transform.position = worldPos; // Move the preview to follow the mouse
        }
    }

    public Tower GetSelectedTower()
    {
        if (selectedTower == -1) return null; // No tower selected
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        if (_selectedTower == -1)
        {
            if(preview != null) Destroy(preview);
            isPlacingTower = false;
            selectedTower = _selectedTower;
            CloseExitSelect();
            return;
        }
        selectedTower = _selectedTower;

        preview = Instantiate(towers[selectedTower].prefabPreview, new Vector3(500, 0, 0), Quaternion.identity); // Spawn preview off of screen
        isPlacingTower = true;
        OpenExitSelect();
    }

    public void OpenExitSelect()
    {
        exitSelect.SetActive(true);
    }

    public void CloseExitSelect()
    {
        exitSelect.SetActive(false);
    }
}