using System.Collections;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private TMP_Text reputationText;
    [SerializeField] private GameObject gameOverBg;
    [SerializeField] private GameObject gameOverScreen;

    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    public int reputation;

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        currency = 30; // start money
        reputation = 100; // start rep
        reputationText.text = reputation.ToString() + "/100";
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }

        else
        {
            Debug.Log("Insufficient funds");
            return false;
        }
    }

    public void DecreaseReputation(int amount)
    {
        if (reputation > amount)
        {
            reputation -= amount;
        }
        else
        {
            reputation = 0;
            GameOver();
        }
        reputationText.text = reputation.ToString() + "/100";
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
        gameOverBg.SetActive(true);
        StartCoroutine(ShowGameOverScreen());
    }

    IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameOverScreen.SetActive(true);
    }

    public void Exit()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
