using System;
using System.Linq;
using PlayFab.AuthenticationModels;
using UnityEngine;
using TMPro;

public class UserInput : MonoBehaviour
{
    public TMP_InputField startInputField;
    PlayfabManager _accountManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startInputField.Select();
        _accountManager = GetComponent<PlayfabManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Convert.ToString(startInputField.text.Substring(0, 5)) == "su - ")
            {
                _accountManager.Login(startInputField.text.Substring(5));
            }
        }
    }
}
