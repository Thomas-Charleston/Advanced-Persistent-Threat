using UnityEngine;
using TMPro; 
public class UpTime : MonoBehaviour
{
    public float time;

    [SerializeField]
    private TMP_Text upTimeText;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime; // Scale time by fast forward multiplier
        upTimeText.text = time.ToString("F0") + "s";
    }
}
