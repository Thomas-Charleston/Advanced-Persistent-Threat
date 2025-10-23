using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI consoleMessage;
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
    
    public void Login(string username, string password, System.Action<bool> onComplete = null)
    {
        Debug.Log(username);
        Debug.Log(password);
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password
        };
        PlayFabClientAPI.LoginWithPlayFab(request, 
            (result) => ConsoleLoginSuccess(result, onComplete), 
            (error) => ConsoleError(error, onComplete));
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful.");
        messageText.text = "Login successful.";
    }

    void ConsoleLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful.");
        consoleMessage.text = "Login successful.";
    }

    void ConsoleLoginSuccess(LoginResult result, System.Action<bool> onComplete)
    {
        Debug.Log("Login successful.");
        consoleMessage.text = "Login successful.";
        onComplete?.Invoke(true); // Notify that login succeeded
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
    }

    void ConsoleError(PlayFabError error)
    {
        consoleMessage.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
    }

    void ConsoleError(PlayFabError error, System.Action<bool> onComplete)
    {
        consoleMessage.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
        onComplete?.Invoke(false); // Notify that login failed
    }
    
    public void StartGame()
    {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene("HomeScreen");
    }
}