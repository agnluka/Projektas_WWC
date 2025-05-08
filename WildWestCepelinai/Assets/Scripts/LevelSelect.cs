using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GediminoPilis()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("Game");
    }

    public void Menulis()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("Game");
    }

    public void Platformos()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("Game");
    }
}
