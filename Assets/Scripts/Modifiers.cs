using UnityEngine;

public class Modifiers : MonoBehaviour
{
    public string mapType;
    public string speedType;
    public string travelType;
    public string accessType;
    public string connectionType;
    public bool penTest;

    void Start()
    {
        if (ModifierButtonScript.Instance != null)
        {
            mapType = ModifierButtonScript.Instance.mapType;
            speedType = ModifierButtonScript.Instance.speedType;
            travelType = ModifierButtonScript.Instance.travelType;
            accessType = ModifierButtonScript.Instance.accessType;
            connectionType = ModifierButtonScript.Instance.connectionType;
            penTest = ModifierButtonScript.Instance.penTest;
        }
        else {
            Debug.LogError("Modifiers: ModifierButtonScript instance not found. Using default values.");
            mapType = "Bus";
            speedType = "Twisted Pair";
            travelType = "Circuit Switch";
            accessType = "Private";
            connectionType = "Wired";
            penTest = false;
        }
    }
}
