using System.Net.Http.Headers;
using UnityEngine;
using TMPro;

public class Date : MonoBehaviour
{
    public TMP_Text timeDisplay;
    void FixedUpdate()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd MMM HH:mm");
        timeDisplay.text= time;
    }
}
