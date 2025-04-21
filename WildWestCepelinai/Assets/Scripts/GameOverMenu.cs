using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject Timer;

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Timer.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}

