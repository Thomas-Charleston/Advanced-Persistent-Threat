using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text currencyDisplay;

    void OnGUI()
    {
        currencyDisplay.text = "$" + LevelManager.main.currency.ToString();
    }

    public void SetSelected()
    {
        
    }
}