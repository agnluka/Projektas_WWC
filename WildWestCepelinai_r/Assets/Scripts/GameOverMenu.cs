using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject Timer;

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Timer.SetActive(false);
    }

    public void RestartGame()
    {
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
    }

    public void QuitToMenu()
    {
       //Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
        gameOverScreen.SetActive(false);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
        gameOverScreen.SetActive(false);
    }
}

