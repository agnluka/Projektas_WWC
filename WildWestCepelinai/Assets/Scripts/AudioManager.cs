using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Background Music")]
    public AudioClip backgroundMusicClip;
    public AudioSource backgroundMusicSource;

    [Header("Sound Effects")]
    public AudioClip walkingSound;
    public AudioClip jumpSound;
    public AudioClip shootingSound;
    public AudioClip hitSound;
    public AudioSource sfxSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize Background Music
            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.playOnAwake = false; // Disable playOnAwake to manually start it
            backgroundMusicSource.volume = 1f;
            backgroundMusicSource.Play(); // Start music explicitly

            // Initialize Sound Effects
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.volume = 1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = Mathf.Clamp01(volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }
}
