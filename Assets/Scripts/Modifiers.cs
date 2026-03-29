using System.Collections;
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
        Debug.Log($"Modifiers Start: Instance is {(ModifierButtonScript.Instance != null ? "present" : "null")}");

        if (ModifierButtonScript.Instance == null)
        {
            ModifierButtonScript found = Object.FindAnyObjectByType<ModifierButtonScript>();
            if (found != null)
            {
                Debug.Log("Modifiers Start: found ModifierButtonScript in scene with FindAnyObjectByType.");
            }
        }

        if (ModifierButtonScript.Instance == null)
        {
            Debug.Log("Modifiers Start: waiting for ModifierButtonScript instance to be available...");
            StartCoroutine(WaitForModifierButtonScript());
            return;
        }

        ApplyModifierSettings();
    }

    private IEnumerator WaitForModifierButtonScript()
    {
        yield return new WaitUntil(() => ModifierButtonScript.Instance != null);

        Debug.Log("Modifiers: ModifierButtonScript became available.");
        ApplyModifierSettings();
    }

    private void ApplyModifierSettings()
    {
        if (ModifierButtonScript.Instance != null)
        {
            mapType = ModifierButtonScript.Instance.mapType;
            speedType = ModifierButtonScript.Instance.speedType;
            travelType = ModifierButtonScript.Instance.travelType;
            accessType = ModifierButtonScript.Instance.accessType;
            connectionType = ModifierButtonScript.Instance.connectionType;
            penTest = ModifierButtonScript.Instance.penTest;
            Debug.Log("Modifiers: loaded values from ModifierButtonScript instance.");
        }
        else
        {
            Debug.LogError("Modifiers: ModifierButtonScript instance not found after waiting. Using default values.");
            mapType = "Bus";
            speedType = "Twisted Pair";
            travelType = "Circuit Switch";
            accessType = "Private";
            connectionType = "Wired";
            penTest = false;
        }
    }
}
