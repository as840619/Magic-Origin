using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioContrpller : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }
}
