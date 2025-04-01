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
        SceneManager.LoadScene("SampleScene");
    }

    public void Menulis()
    {
        SceneManager.LoadScene("Menulis");
    }
}
