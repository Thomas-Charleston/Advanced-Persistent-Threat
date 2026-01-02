using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recruit : MonoBehaviour
{
    [SerializeField]
    private TMP_Text analystSelectText;
    [SerializeField]
    private TMP_Text engineerSelectText;
    [SerializeField]
    private TMP_Text adminSelectText;
    [SerializeField]
    private TMP_Text teacherSelectText;
    [SerializeField]
    private TMP_Text redTeamerSelectText;
    [SerializeField]
    private TMP_Text responderSelectText;
    [SerializeField]
    private TMP_Text currentHeroText;
    [SerializeField]
    private GameObject analystBorder;
    private string hero;
    
    // Checks for a previously selected hero; if none exists, defaults to "Analyst"
    void Start()
    {
        hero = PlayerPrefs.GetString("SelectedHero");
        // Use GetComponent once instead
        analystBorder.GetComponent<Image>().color = new Color32(88, 88, 87, 255);
        if(string.IsNullOrEmpty(hero))
        {
            SelectAnalyst();
        }
        else if(hero == "Analyst")
        {
            SelectAnalyst();
        }
        else if(hero == "Engineer")
        {
            SelectEngineer();
        }
        else if(hero == "Admin")
        {
            SelectAdmin();
        }
        else if(hero == "Teacher")
        {
            SelectTeacher();
        }
        else if(hero == "RedTeamer")
        {
            SelectRedTeamer();
        }
        else if(hero == "Responder")
        {
            SelectResponder();
        }
    }

    // Methods to select each hero type and update UI and PlayerPrefs accordingly
    // Change to use coroutines?
    public void SelectAnalyst()
    {
        hero = "Analyst";
        analystSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        engineerSelectText.text = "Select";
        adminSelectText.text = "Select";
        teacherSelectText.text = "Select";
        redTeamerSelectText.text = "Select";
        responderSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void SelectEngineer()
    {
        analystBorder.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        hero = "Engineer";
        engineerSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        analystSelectText.text = "Select";
        adminSelectText.text = "Select";
        teacherSelectText.text = "Select";
        redTeamerSelectText.text = "Select";
        responderSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void SelectAdmin()
    {
        analystBorder.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        hero = "Admin";
        adminSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        analystSelectText.text = "Select";
        engineerSelectText.text = "Select";
        teacherSelectText.text = "Select";
        redTeamerSelectText.text = "Select";
        responderSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void SelectTeacher()
    {
        analystBorder.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        hero = "Teacher";
        teacherSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        analystSelectText.text = "Select";
        engineerSelectText.text = "Select";
        adminSelectText.text = "Select";
        redTeamerSelectText.text = "Select";
        responderSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void SelectRedTeamer()
    {
        analystBorder.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        hero = "RedTeamer";
        redTeamerSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        analystSelectText.text = "Select";
        engineerSelectText.text = "Select";
        adminSelectText.text = "Select";
        teacherSelectText.text = "Select";
        responderSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void SelectResponder()
    {
        analystBorder.GetComponent<Image>().color = new Color32(89, 89, 89, 255);
        hero = "Responder";
        responderSelectText.text = "Selected";
        PlayerPrefs.SetString("SelectedHero", hero);
        PlayerPrefs.Save();
        analystSelectText.text = "Select";
        engineerSelectText.text = "Select";
        adminSelectText.text = "Select";
        teacherSelectText.text = "Select";
        redTeamerSelectText.text = "Select";
        currentHeroText.text = "Current: " + hero;
    }

    public void RecruitInfo()
    {
        Debug.Log("Give recruit info");
    }
}
