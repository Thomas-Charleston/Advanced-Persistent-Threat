using PlayFab.EventsModels;
using UnityEngine;

public class ApplicationScript : MonoBehaviour
{
    public GameObject balance;
    public GameObject mail;
    public GameObject defend;
    public GameObject recruit;
    public GameObject vault;
    public GameObject settings;
    public GameObject documentation;
    public GameObject profile;
    [SerializeField]
    private GameObject modifiers;

    public void OpenBalance()
    {
        balance.SetActive(true);
    }

    public void OpenMail()
    {
        mail.SetActive(true);
    }

    public void OpenDefend()
    {
        defend.SetActive(true);
        Debug.Log("defend");
    }

    public void OpenRecruit()
    {
        recruit.SetActive(true);
        Debug.Log("Recruit");
    }

    public void OpenVault()
    {
        vault.SetActive(true);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void OpenDocumentation()
    {
        documentation.SetActive(true);
    }

    public void OpenProfile()
    {
        profile.SetActive(true);
    }



    public void CloseBalance()
    {
        balance.SetActive(false);
    }

    public void CloseMail()
    {
        mail.SetActive(false);
    }

    public void CloseDefend()
    {
        defend.SetActive(false);
    }

    public void CloseRecruit()
    {
        recruit.SetActive(false);
    }

    public void CloseVault()
    {
        vault.SetActive(false);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void CloseDocumentation()
    {
        documentation.SetActive(false);
    }

    public void CloseProfile()
    {
        profile.SetActive(false);
    }

    public void CloseModifiers()
    {
        modifiers.SetActive(false);
    }
    
}

    // public void CloseAppliaction()
    // {
    //     balance.SetActive(false);
    // }

    // public void openApplication()
    // {
    //     gameObject.SetActive(true);
    // }

    
