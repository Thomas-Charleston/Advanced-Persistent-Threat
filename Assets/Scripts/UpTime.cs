using UnityEngine;
using TMPro; 
public class UpTime : MonoBehaviour
{
    public float time;
    public float gameWinTime = 60f;

    [Header("References")]
    [SerializeField] private TMP_Text upTimeText;
    [SerializeField] private GameObject gameWinScreen;
    

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime; // Scale time by fast forward multiplier
        upTimeText.text = time.ToString("F0") + "s";

        if (time >= gameWinTime)
        {
            Time.timeScale = 0f;
            gameWinScreen.SetActive(true);
        }
    }
}
