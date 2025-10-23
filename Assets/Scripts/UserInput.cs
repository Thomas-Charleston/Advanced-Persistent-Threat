using System;
using System.Linq;
using PlayFab.AuthenticationModels;
using UnityEngine;
using TMPro;

public class UserInput : MonoBehaviour
{
    public TMP_InputField startInputField;
    public GameObject passwordLine;
    public GameObject followUpText;
    public TMP_InputField passwordInputField;
    public TMP_InputField startCommandInputField;
    PlayfabManager _accountManager;
    private bool waitingForPassword = false;
    private bool loggedIn = false;

    void Start()
    {
        passwordLine.SetActive(false);
        followUpText.SetActive(false);
        startInputField.Select();
        _accountManager = GetComponent<PlayfabManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!waitingForPassword && !loggedIn)
            {
                // First Enter: Check for "su - username" command
                if (startInputField.text.Length >= 5 && startInputField.text.Substring(0, 5) == "su - ")
                {
                    passwordLine.SetActive(true);
                    passwordInputField.Select();
                    passwordInputField.textComponent.color = new Color(0, 0, 0, 0);
                    waitingForPassword = true;
                }
            }

            else if (waitingForPassword)
            {
                // Second Enter: Attempt login with password
                Debug.Log("Login attempt");
                string username = startInputField.text.Substring(5);
                string password = passwordInputField.text;
                
                // Wait for login to complete before continuing
                _accountManager.Login(username, password, (loginSuccessful) => {
                    if (loginSuccessful)
                    {
                        waitingForPassword = false;
                        loggedIn = true;
                        followUpText.SetActive(true);
                        startCommandInputField.Select();
                        Debug.Log("Login completed successfully");
                    }
                    else
                    {
                        Debug.Log("Login failed - try again");
                        // Reset password field for retry
                        passwordInputField.text = "";
                        passwordInputField.Select();
                    }
                });
            }

            else if (loggedIn)
            {
                // Third Enter: Start Game
                if (startCommandInputField.text == "./APT")
                {
                    _accountManager.StartGame();
                }

                else
                {
                    Debug.Log("Invalid command. To start the game, type './APT'");
                }
            }
        }
    }
}
