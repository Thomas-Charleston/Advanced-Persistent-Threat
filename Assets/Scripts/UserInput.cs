using System;
using System.Linq;
using PlayFab.AuthenticationModels;
using UnityEngine;
using TMPro;
using System.Collections;

public class UserInput : MonoBehaviour
{
    public TMP_InputField startInputField;
    public GameObject passwordLine;
    public GameObject followUpText;
    public TMP_Text followUpHelpCommand;
    public TMP_InputField passwordInputField;
    public TMP_InputField startCommandInputField;
    public TMP_Text followUpPath;
    public TMP_Text runGameError;
    PlayfabManager _accountManager;
    private bool waitingForPassword = false;
    private bool waitingToCreateUser = false;
    private bool loggedIn = false;

    public GameObject passwordCreateCommand;
    public TMP_InputField passwordCreateCommandField;
    public GameObject passwordCreateHelpMessage;
    private string newUsername;

    public GameObject newPasswordLine;
    public TMP_InputField newPasswordInput;
    private bool waitingForNewPassword;
    public TMP_Text registerSuccessLine;

    void Start()
    {
        passwordLine.SetActive(false);
        followUpText.SetActive(false);
        passwordCreateHelpMessage.SetActive(false);
        newPasswordLine.SetActive(false);
        passwordCreateCommand.SetActive(false);
        startInputField.Select();
        _accountManager = GetComponent<PlayfabManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (waitingForNewPassword)
            {
                // Third Enter: Create new password
                Debug.Log("Account creation attempt");
                if (ValidatePassword(newPasswordInput.text))
                {
                    string newPassword = newPasswordInput.text;
                    _accountManager.Register(newUsername, newPassword, (creationSuccessful) =>
                    {
                        if (creationSuccessful)
                        {
                            waitingForNewPassword = false;
                            Debug.Log("Account creation successful. You can now log in.");
                            // Reset input fields so user can login with new account
                            StartCoroutine(ResetAfterDelay(2.5f));
                        }

                        else
                        {
                            Debug.Log("Account creation failed - try again");
                            // Reset input fields for retry
                            startInputField.text = "";
                            passwordCreateCommandField.text = "";
                            newPasswordInput.text = "";
                            startInputField.ActivateInputField();
                            startInputField.Select();
                            waitingForNewPassword = false;
                        }
                    });
                }

                else
                {
                    Debug.Log("Invalid password.");
                    registerSuccessLine.text = "Password too weak. Requirements: Min 6 chars, 1 uppercase, 1 lowercase, 1 digit.";
                    newPasswordInput.text = "";
                    newPasswordInput.ActivateInputField();
                    newPasswordInput.Select();
                }
                

                // skip the rest of the update handling this frame
                return;
            }

            if (!waitingForPassword && !loggedIn && !waitingToCreateUser)
            {
                // First Enter: Check for "su - username" command
                if (startInputField.text.Length >= 5 && startInputField.text.Substring(0, 5) == "su - ")
                {
                    passwordLine.SetActive(true);
                    passwordInputField.Select();
                    passwordInputField.textComponent.color = new Color(0, 0, 0, 0);
                    waitingForPassword = true;
                }

                // Check for "sudo adduser username" command
                else if (startInputField.text.Length >= 13 && startInputField.text.StartsWith("sudo adduser "))
                {
                    newUsername = startInputField.text.Substring(13);
                    // Validates username
                    if (ValidateUsername(newUsername))
                    {
                        // passwordLine.SetActive(true);
                        // passwordInputField.Select();
                        // passwordInputField.textComponent.color = new Color(0, 0, 0, 0);
                        passwordCreateHelpMessage.SetActive(true);
                        passwordCreateCommand.SetActive(true);
                        passwordCreateCommandField.Select();
                        waitingToCreateUser = true;
                    }

                    else
                    {
                        Debug.Log("Invalid username. Usernames must be alphanumeric and between 3 and 16 characters.");
                        startInputField.text = "";
                        startInputField.ActivateInputField();
                        startInputField.Select();
                    }
                }

                // Throws error for any other command
                else
                {
                    Debug.Log("Invalid command.");
                    startInputField.text = "";
                    startInputField.ActivateInputField();
                    startInputField.Select();
                }
            }

            else if (waitingForPassword)
            {
                // Second Enter: Attempt login with password
                Debug.Log("Login attempt");
                string username = startInputField.text.Substring(5);
                string password = passwordInputField.text;

                // Wait for login to complete before continuing
                _accountManager.Login(username, password, (loginSuccessful) =>
                {
                    if (loginSuccessful)
                    {
                        waitingForPassword = false;
                        loggedIn = true;
                        followUpText.SetActive(true);

                        // first attempt at code below
                        // followUpHelpCommand.text = $"{username}@APT:~$ Help";
                        // int usernameLength = username.Length;
                        // followUpHelpCommand.text.Substring(usernameLength + 7, 4).color = new Color(1, 1, 1);

                        followUpHelpCommand.richText = true;
                        string prefix = $"{username}@APT:~";
                        string last = "Help";
                        string colorHex = ColorUtility.ToHtmlStringRGB(new Color(1, 1, 1));
                        string path = $"{prefix} <color=#{colorHex}>$ </color>";
                        followUpHelpCommand.text = $"{path}<color=#{colorHex}>{last}</color>";

                        followUpPath.text = path;


                        startCommandInputField.Select();
                        Debug.Log("Login completed successfully");
                    }
                    else
                    {
                        waitingForPassword = false;
                        Debug.Log("Login failed - try again");
                        // Reset input fields for retry
                        startInputField.text = "";
                        passwordInputField.text = "";
                        startInputField.Select();
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
                    runGameError.gameObject.SetActive(true);

                    startCommandInputField.text = "";
                    startCommandInputField.ActivateInputField();
                    startCommandInputField.Select();
                }
            }

            else if (waitingToCreateUser)
            {
                // Second Enter: Command to create new password
                if (passwordCreateCommandField.text == $"sudo passwd {newUsername}")
                {
                    waitingToCreateUser = false;
                    newPasswordLine.SetActive(true);
                    newPasswordInput.textComponent.color = new Color(0, 0, 0, 0);
                    newPasswordInput.Select();
                    waitingForNewPassword = true;
                }

                else
                {
                    passwordCreateCommandField.text = "";
                    passwordCreateCommandField.Select();
                }
            }
        }
    }


    private bool ValidateUsername(string username)
    {
        // Username must be alphanumeric and between 3 and 16 characters
        if (username.Length < 3 || username.Length > 16)
            return false;

        return username.All(c => Char.IsLetterOrDigit(c));
    }

    private bool ValidatePassword(string password)
    {
        // Length check
        if (password.Length < 6)
            return false;

        // Check for at least one uppercase letter
        if (!password.Any(char.IsUpper))
            return false;

        // Check for at least one lowercase letter
        if (!password.Any(char.IsLower))
            return false;

        // Check for at least one digit
        if (!password.Any(char.IsDigit))
            return false;

        return true;
    }

    private void ResetForLogin()
    {
        startInputField.text = "";
        passwordInputField.text = "";
        passwordCreateCommandField.text = "";
        newPasswordInput.text = "";

        passwordLine.SetActive(false);
        followUpText.SetActive(false);
        passwordCreateHelpMessage.SetActive(false);
        passwordCreateCommand.SetActive(false);
        newPasswordLine.SetActive(false);
        registerSuccessLine.gameObject.SetActive(false);

        startInputField.ActivateInputField();
        startInputField.Select();
    }
    
    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetForLogin();
    }
}
