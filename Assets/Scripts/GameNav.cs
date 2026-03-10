using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameNav : MonoBehaviour
{
    // Singleton pattern for easy access to game state across scripts
    private static GameNav instance;
    public static GameNav Instance { get { return instance; } }

    public bool isPaused = false;
    private bool fastForward = false;
    [SerializeField] private float ffMult = 2f;
    public float activeFf = 1f;
    [SerializeField] private Image ffImage;
    [SerializeField] private Image pauseImage;
    [SerializeField] private Image consoleImage;
    [SerializeField] private Image settingsImage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
    }

    void Start()
    {
        setColourStart();
    }

    public void setColourStart()
    {
        ffImage.color = new Color32(255, 255, 255, 100);
        pauseImage.color = new Color32(255, 255, 255, 100);
        consoleImage.color = new Color32(255, 255, 255, 255);
        settingsImage.color = new Color32(255, 255, 255, 100);
    }

    public void FastForward()
    {
        if (isPaused)
        {
            PlayGame();
            pauseImage.color = new Color32(255, 255, 255, 100);
        }
        else if (fastForward)
        {
            fastForward = false;
            activeFf = 1f;
            Time.timeScale = activeFf;
            ffImage.color = new Color32(255, 255, 255, 100);
        }
        else
        {
            fastForward = true;
            activeFf = ffMult;
            Time.timeScale = activeFf;
            ffImage.color = new Color32(255, 255, 255, 255);
        }
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            PlayGame();
            pauseImage.color = new Color32(255, 255, 255, 100);
        }
        else
        {
            PauseGame();
            pauseImage.color = new Color32(255, 255, 255, 255);
            ffImage.color = new Color32(255, 255, 255, 100);
        }
    }

    public void OpenConsole(GameObject gamePanel)
    {
        gamePanel.SetActive(true);
        consoleImage.color = new Color32(255, 255, 255, 255);
    }
    
    public void CloseConsole(GameObject gamePanel)
    {
        gamePanel.SetActive(false);
        consoleImage.color = new Color32(255, 255, 255, 100);
    }

    public void OpenSettings(GameObject settingsPanel)
    {
        settingsPanel.SetActive(true);
        settingsImage.color = new Color32(255, 255, 255, 255);
    }

    public void CloseSettings(GameObject settingsPanel)
    {
        settingsPanel.SetActive(false);
        settingsImage.color = new Color32(255, 255, 255, 100);
    }

    public void PlayGame()
    {
        isPaused = false;
        activeFf = 1f;
        Time.timeScale = activeFf;
        Debug.Log("Play");
    }

    public void PauseGame()
    {
        isPaused = true; // Need  to implement pause functionality
        fastForward = false;
        activeFf = 0f;
        Time.timeScale = 0f;
        Debug.Log("Pause");
    }
}
