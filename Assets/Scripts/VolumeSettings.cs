using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volText;
    [SerializeField] private AudioSource source;

    void Start()
    {
        volumeSlider.value = 1f;
        source.volume = 1f;
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        source.volume = volume;
        volText.text = (Convert.ToInt16(100 * volumeSlider.value)).ToString() + "%";
    }
}
