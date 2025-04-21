using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TogglePause : MonoBehaviour
{
    public GameObject menu;

    public static bool isPaused = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        enabled = false;
        menu.SetActive(false);
        yield return new WaitForSeconds(3);
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            menu.SetActive(isPaused);
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void QuitToMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
