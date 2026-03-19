using TMPro;
using UnityEngine;

public class DataValue : MonoBehaviour
{
    public static DataValue main;

    public float data;
    
    [Header("References")]
    [SerializeField] private TMP_Text dataValueText;

    void Awake()
    {
        main = this;
    }
    
    void Start()
    {
        data = 0;
    }

    private void UpdateText()
    {
        if (data < 4)
        {
            dataValueText.text = data.ToString() + " bits";
        }
        else if (data < 8)
        {
            dataValueText.text = (data/4).ToString() + " nibbles";
        }
        else if (data < 8000)
        {
            dataValueText.text = (data/8).ToString() + " Bytes";
        }
        else
        {
            dataValueText.text = (data/8000).ToString() + "KB";
        }
    }

    public void AddData(int value)
    {
        if (value + data < 0) data = 0; // So net data doesn't become negative
        else {data += value;}
        UpdateText();
    }
}
