using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class ModifierData
{
    public string mapType;
    public string speedType;
    public string travelType;
    public string accessType;
    public string connectionType;
    public bool penTest;
}

public class ModifierButtonScript : MonoBehaviour
{
    // Given default values
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

    private ModifierData data = new ModifierData();
    private bool isLoading = false;
    private static ModifierButtonScript instance;
    public static ModifierButtonScript Instance { get { return instance; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad only works on root GameObjects, so traverse to root
            Transform root = transform.root;
            DontDestroyOnLoad(root.gameObject);
            Debug.Log($"ModifierButtonScript Awake: instance set on {gameObject.name}, marked root {root.gameObject.name} as persistent");
        }
        else
        {
            Debug.LogWarning($"ModifierButtonScript duplicate found at {gameObject.name}, destroying");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log($"ModifierButtonScript Start: instance is {(instance != null ? "valid" : "null")}");
        LoadData();
    }

    public void TwistedPair()
    {
        speedType = "Twisted Pair";
        data.speedType = speedType;
        twistedBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        coaxBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        fibreBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }
    public void Coaxial()
    {
        speedType = "Coaxial";
        data.speedType = speedType;
        twistedBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        coaxBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        fibreBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void FibreOptic()
    {
        speedType = "Fibre Optic";
        data.speedType = speedType;
        twistedBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        coaxBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        fibreBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void CircuitSwitch()
    {
        travelType = "Circuit Switch";
        data.travelType = travelType;
        circuitBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        packetBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void PacketSwitch()
    {
        travelType = "Packet Switch";
        data.travelType = travelType;
        circuitBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        packetBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void Private()
    {
        accessType = "Private";
        data.accessType = accessType;
        privateBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        publicBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void Public()
    {
        accessType = "Public";
        data.accessType = accessType;
        privateBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        publicBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void Wired()
    {
        connectionType = "Wired";
        data.connectionType = connectionType;
        wiredBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        wirelessBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void Wireless()
    {
        connectionType = "Wireless";
        data.connectionType = connectionType;
        wiredBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        wirelessBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void PenTestOn()
    {
        penTest = true;
        data.penTest = penTest;
        penTestBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        noPenTestBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void PenTestOff()
    {
        penTest = false;
        data.penTest = penTest;
        penTestBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        noPenTestBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void Bus()
    {
        mapType = "Bus";
        data.mapType = mapType;
        busBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        starBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        meshBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void Star()
    {
        mapType = "Star";
        data.mapType = mapType;
        busBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        starBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        meshBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        if (!isLoading) SaveData();
    }

    public void Mesh()
    {
        mapType = "Mesh";
        data.mapType = mapType;
        busBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        starBg.GetComponent<Image>().color = new Color32(65, 65, 65, 150);
        meshBg.GetComponent<Image>().color = new Color32(53, 53, 53, 255);
        if (!isLoading) SaveData();
    }

    public void LoadGame()
    {
        Debug.Log("Load game with settings");
        SceneManager.LoadScene("Game");
    }

    public void ModifierInfo()
    {
        Debug.Log("Give modifier info");
    }

    private void SaveData()
    {
        string path = Application.persistentDataPath + "/modifierData.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/modifierData.json";
        if (!File.Exists(path))
        {
            data.mapType = "Bus";
            data.speedType = "Twisted Pair";
            data.travelType = "Circuit Switch";
            data.accessType = "Private";
            data.connectionType = "Wired";
            data.penTest = false;
        }
        else
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<ModifierData>(json);
        }
        mapType = data.mapType;
        speedType = data.speedType;
        travelType = data.travelType;
        accessType = data.accessType;
        connectionType = data.connectionType;
        penTest = data.penTest;
        isLoading = true;
        if (speedType == "Twisted Pair") TwistedPair();
        else if (speedType == "Coaxial") Coaxial();
        else if (speedType == "Fibre Optic") FibreOptic();
        if (travelType == "Circuit Switch") CircuitSwitch();
        else PacketSwitch();
        if (accessType == "Private") Private();
        else Public();
        if (connectionType == "Wired") Wired();
        else Wireless();
        if (penTest) PenTestOn();
        else PenTestOff();
        if (mapType == "Bus") Bus();
        else if (mapType == "Star") Star();
        else Mesh();
        isLoading = false;
    }   
}
