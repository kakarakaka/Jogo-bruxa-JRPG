using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        float volume = 1f;

        volumeSlider.value = volume;

        AudioListener.volume = volume;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat(
            "MasterVolume",
            volume);
    }
}