using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private static AudioScript instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this object across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }
}
