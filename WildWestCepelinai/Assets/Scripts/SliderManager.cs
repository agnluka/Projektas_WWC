using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider backgroundMusicSlider;
    public Slider soundEffectsSlider;

    void Start()
    {
        // Set initial slider values from AudioManager (optional)
        if (AudioManager.instance != null)
        {
            backgroundMusicSlider.value = AudioManager.instance.backgroundMusicSource.volume; // Corrected line
            soundEffectsSlider.value = AudioManager.instance.sfxSource.volume;
        }

        // Add listeners to the sliders
        backgroundMusicSlider.onValueChanged.AddListener(OnBackgroundMusicVolumeChanged);
        soundEffectsSlider.onValueChanged.AddListener(OnSoundEffectsVolumeChanged);
    }

    public void OnBackgroundMusicVolumeChanged(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetBackgroundMusicVolume(volume);
        }
    }

    public void OnSoundEffectsVolumeChanged(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSoundEffectsVolume(volume);
        }
    }
}