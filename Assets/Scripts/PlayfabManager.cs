using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI messageText;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button registerButton;

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 8)
        {
            messageText.text = "Password must be at least 8 characters long.";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registration successful.");
        messageText.text = "Registration successful.";
    }

    public void LoginButton()
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = usernameInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful.");
        messageText.text = "Login successful.";
    }

    void OnError(PlayFabError error){
        messageText.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
    }
}