using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    public TextMeshProUGUI consoleMessageLogin;
    public TextMeshProUGUI consoleMessageRegister;
    public TextMeshProUGUI consoleRegisterMessage;
    
    // [Header("UI")]
    // public TextMeshProUGUI messageText;
    // public TMP_InputField usernameInput;
    // public TMP_InputField passwordInput;
    // public Button registerButton;

    // public void RegisterButton()
    // {
    //     if (passwordInput.text.Length < 8)
    //     {
    //         messageText.text = "Password must be at least 8 characters long.";
    //         return;
    //     }

    //     var request = new RegisterPlayFabUserRequest
    //     {
    //         Username = usernameInput.text,
    //         Password = passwordInput.text,
    //         RequireBothUsernameAndEmail = false
    //     };
    //     PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    // }

    // void OnRegisterSuccess(RegisterPlayFabUserResult result)
    // {
    //     Debug.Log("Registration successful.");
    //     messageText.text = "Registration successful.";
    // }

    // public void LoginButton()
    // {
    //     var request = new LoginWithPlayFabRequest
    //         {
    //         Username = usernameInput.text,
    //         Password = passwordInput.text
    //     };
    //     PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    // }

    // void OnLoginSuccess(LoginResult result)
    // {
    //     Debug.Log("Login successful.");
    //     messageText.text = "Login successful.";
    // }

    // void OnError(PlayFabError error)
    // {
    //     messageText.text = error.ErrorMessage;
    //     Debug.Log("Error: " + error.GenerateErrorReport());
    // }
    
    public void Register(string username, string password, System.Action<bool> onComplete = null)
    {
        Debug.Log(username);
        var request = new RegisterPlayFabUserRequest
        {
            Username = username,
            Password = password,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, 
            (result) => ConsoleRegisterSuccess(result, onComplete), 
            (error) => ConsoleRegisterError(error, onComplete));
    }

    public void Login(string username, string password, System.Action<bool> onComplete = null)
    {
        Debug.Log(username);
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password
        };
        PlayFabClientAPI.LoginWithPlayFab(request, 
            (result) => ConsoleLoginSuccess(result, onComplete), 
            (error) => ConsoleLoginError(error, onComplete));
    }

    void ConsoleLoginSuccess(LoginResult result, System.Action<bool> onComplete)
    {
        Debug.Log("Login successful.");
        consoleMessageLogin.text = "Login successful.";
        onComplete?.Invoke(true); // Notify login success
    }

    void ConsoleRegisterSuccess(RegisterPlayFabUserResult result, System.Action<bool> onComplete)
    {
        Debug.Log("Registration successful.");
        consoleMessageRegister.text = "Registration successful.";
        onComplete?.Invoke(true); // Notify registration success
    }

    void ConsoleLoginError(PlayFabError error, System.Action<bool> onComplete)
    {
        consoleMessageLogin.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
        onComplete?.Invoke(false); // Notify login failed
    }
    
    void ConsoleRegisterError(PlayFabError error, System.Action<bool> onComplete)
    {
        consoleMessageRegister.text = error.ErrorMessage;
        Debug.Log("Error: " + error.GenerateErrorReport());
        onComplete?.Invoke(false); // Notify registration failed
    }
    




    public void StartGame()
    {
        Debug.Log("Starting Game...");
        SceneManager.LoadScene("HomeScreen");
    }
}