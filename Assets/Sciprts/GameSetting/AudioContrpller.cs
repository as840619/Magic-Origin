using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioContrpller : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }
}