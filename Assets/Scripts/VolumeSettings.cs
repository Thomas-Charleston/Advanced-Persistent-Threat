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
    [SerializeField] private AudioSource enemyDestroyedSource;
    [SerializeField] private AudioSource enemyReachesEndSource;

    void Start()
    {
        volumeSlider.value = 1f;
        AudioListener.volume = 1f;
        enemyDestroyedSource.volume = 1f;
        enemyReachesEndSource.volume = 1f;
    }

    public void SetVolume()
    {
        float volume = volumeSlider.value;
        AudioListener.volume = volume;
        enemyDestroyedSource.volume = volume;
        enemyReachesEndSource.volume = volume;
        volText.text = (Convert.ToInt16(100 * volumeSlider.value)).ToString() + "%";
    }
}
