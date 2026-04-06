using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class Terminal : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text userText1;
    [SerializeField] private TMP_Text userText2;
    
    public string username;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        username = PlayerPrefs.GetString("PlayFabUsername", "Unknown");
        userText1.text = $"{username}@APT:~";
        userText2.text = $"{username}@APT:~";
    }
}
