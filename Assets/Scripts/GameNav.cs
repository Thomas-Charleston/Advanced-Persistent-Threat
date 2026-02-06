using UnityEngine;

public class GameNav : MonoBehaviour
{
    public bool isPaused = false;
    private bool fastForward = false;
    [SerializeField] private int ffMult = 2;
    public int activeFf = 1;
    public void FastForward()
    {
        if (isPaused)
        {
            PlayGame();
        }
        else if (fastForward)
        {
            fastForward = false;
            activeFf = 1;
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
        isPaused = true;
    }

    public void PauseGame()
    {
        isPaused = false;
    }
}
