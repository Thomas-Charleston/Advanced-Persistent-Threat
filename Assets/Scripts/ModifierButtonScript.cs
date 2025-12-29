using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ModifierButtonScript : MonoBehaviour
{
    public string mapType = "Bus";
    public string speedType = "Twisted Pair";
    public string travelType = "Circuit Switch";
    public string accessType = "Private";
    public string connectionType = "Wired";
    public bool penTest = false;

    [SerializeField]
    private GameObject twistedBg;
    [SerializeField]
    private GameObject coaxBg;
    [SerializeField]
    private GameObject fibreBg;
    [SerializeField]
    private GameObject circuitBg;
    [SerializeField]
    private GameObject packetBg;
    [SerializeField]
    private GameObject privateBg;
    [SerializeField]
    private GameObject publicBg;
    [SerializeField]
    private GameObject wiredBg;
    [SerializeField]
    private GameObject wirelessBg;
    [SerializeField]
    private GameObject penTestBg;
    [SerializeField]
    private GameObject noPenTestBg;
    [SerializeField]
    private GameObject busBg;
    [SerializeField]
    private GameObject starBg;
    [SerializeField]
    private GameObject meshBg;

 
    public void TwistedPair()
    {
        speedType = "Twisted Pair";
        twistedBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        coaxBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        fibreBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void Coaxial()
    {
        speedType = "Coaxial";
        twistedBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        coaxBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        fibreBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void FibreOptic()
    {
        speedType = "Fibre Optic";
        twistedBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        coaxBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        fibreBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void CircuitSwitch()
    {
        travelType = "Circuit Switch";
        circuitBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        packetBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void PacketSwitch()
    {
        travelType = "Packet Switch";
        circuitBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        packetBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void Private()
    {
        accessType = "Private";
        privateBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        publicBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void Public()
    {
        accessType = "Public";
        privateBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        publicBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void Wired()
    {
        connectionType = "Wired";
        wiredBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        wirelessBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void Wireless()
    {
        connectionType = "Wireless";
        wiredBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        wirelessBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void PenTestOn()
    {
        penTest = true;
        penTestBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        noPenTestBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void PenTestOff()
    {
        penTest = false;
        penTestBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        noPenTestBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void Bus()
    {
        mapType = "Bus";
        busBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        starBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        meshBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void Star()
    {
        mapType = "Star";
        busBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        starBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        meshBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
    }

    public void Mesh()
    {
        mapType = "Mesh";
        busBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        starBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        meshBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
    }

    public void LoadGame()
    {
        Debug.Log("Load game with settings");
    }

    public void ModifierInfo()
    {
        Debug.Log("Give info");
    }
}
