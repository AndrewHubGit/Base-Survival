using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLevel : MonoBehaviour
{
    private Slider _volumeSlider;
    private void Start()
    {
        _volumeSlider = GetComponent<Slider>();
        _volumeSlider.value = PlayerPrefs.GetFloat("audioSetting");
        AudioListener.volume = PlayerPrefs.GetFloat("audioSetting");
    }
    public void AudioSetting(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("audioSetting", volume);
    }
}
