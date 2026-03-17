using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameResultRewards : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text payText;
    [SerializeField] private TMP_Text xpText;
    [SerializeField] private Modifiers modifiers;

    [Header("Attributes")]
    [SerializeField] private float basePay = 50f;
    [SerializeField] private float baseXP = 10f;
    [SerializeField] private float mult = 1f;
    [SerializeField] private float xpMult = 1f;

    private float pay;
    private float xp;

    void Start()
    {
        pay = CalculatePay();
        xp = CalculateXP();
        payText.text = "Pay: " + pay.ToString();
        xpText.text = "Experience: " + xp.ToString();
        GiveRewards();
    }

    private void GiveRewards()
    {
        if (MoneyDisplay.Instance != null)
        {
            MoneyDisplay.Instance.SaveMoney((int)pay);
        }
        // Give XP
    }

    private float CalculatePay()
    {
        if (modifiers.penTest == true)
        {
            return 0f;
        }

        if (modifiers.mapType == "Star")
        {
            mult += 0.5f;
        }
        else if (modifiers.mapType == "Mesh")
        {
            mult += 0.75f;
        }
        
        if (modifiers.speedType == "Coaxial")
        {
            mult += 0.25f;
        }
        else if (modifiers.speedType == "FibreOptic")
        {
            mult += 0.5f;
        }

        if (modifiers.travelType == "PacketSwitch")
        {
            mult += 0.5f;
        }

        if (modifiers.accessType == "public")
        {
            mult += 0.25f;
        }

        if (modifiers.connectionType == "Wireless")
        {
            mult += 0.25f;
        }

        return basePay * mult;
    }

    private float CalculateXP()
    {
        if (modifiers.penTest == true)
        {
            return 0f;
        }

        if (modifiers.mapType == "Star")
        {
            xpMult += 0.5f;
        }
        else if (modifiers.mapType == "Mesh")
        {
            xpMult += 0.75f;
        }
        
        if (modifiers.speedType == "Coaxial")
        {
            xpMult += 0.25f;
        }
        else if (modifiers.speedType == "FibreOptic")
        {
            xpMult += 0.5f;
        }

        if (modifiers.travelType == "PacketSwitch")
        {
            xpMult += 0.5f;
        }

        if (modifiers.accessType == "public")
        {
            xpMult += 0.25f;
        }

        if (modifiers.connectionType == "Wireless")
        {
            xpMult += 0.25f;
        }

        return baseXP * xpMult;
    }
}
