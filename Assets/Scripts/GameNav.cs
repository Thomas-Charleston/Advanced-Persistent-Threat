using UnityEngine;

public class GameNav : MonoBehaviour
{
    // Singleton pattern for easy access to game state across scripts
    private static GameNav instance;
    public static GameNav Instance { get { return instance; } }

    public bool isPaused = false;
    private bool fastForward = false;
    [SerializeField] private float ffMult = 2f;
    public float activeFf = 1f;

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
    }
    public void FastForward()
    {
        if (isPaused)
        {
            PlayGame();
        }
        else if (fastForward)
        {
            fastForward = false;
            activeFf = 1f;
        }
        else
        {
            fastForward = true;
            activeFf = ffMult;
        }
    }

    public void PauseButton()
    {
        if (isPaused)
        {
            PlayGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void OpenGamePanel(GameObject gamePanel)
    {
        gamePanel.SetActive(true);
    }
    
    public void CloseGamePanel(GameObject gamePanel)
    {
        gamePanel.SetActive(false);
    }

    public void PlayGame()
    {
        isPaused = false;
    }

    public void PauseGame()
    {
        isPaused = true; // Need  to implement pause functionality
    }
}
