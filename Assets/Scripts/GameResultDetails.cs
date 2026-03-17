using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameResultDetails : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UpTime upTimeScript;
    [SerializeField] private TMP_Text modifiersText;
    [SerializeField] private TMP_Text uptimeText;
    [SerializeField] private TMP_Text netDataText;
    [SerializeField] private Modifiers modifiers;

    void Start()
    {
        uptimeText.text = "Uptime: " + upTimeScript.time.ToString() + "s";
        modifiersText.text = "Modifiers: " + modifiers.mapType + ", " + modifiers.speedType + ", " + modifiers.travelType + ", " + modifiers.accessType + ", " + modifiers.connectionType + ", PenTest: " + modifiers.penTest.ToString();
        netDataText.text = "Net Data: ";
    }

    public void ContinueFromOver()
    {
        SceneManager.LoadScene("Game");
    }
    
}
