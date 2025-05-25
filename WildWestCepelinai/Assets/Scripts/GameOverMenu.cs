using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject Timer;
    public TMPro.TextMeshProUGUI winnerText;

    public Transform winnerSpawnPoint;
    private GameObject spawnedWinnerModel;

    public static bool isGameOver = false;

    public void gameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
        Timer.SetActive(false);

        ////////////
        Time.timeScale = 0f;

        // REMOVE all player characters from scene
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player);
        }
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

    public void ShowWinner(string winnerName, GameObject winnerObject = null)
    {
        if (winnerText != null)
        {
            winnerText.text = winnerName + " Wins!";
        }

        if (spawnedWinnerModel != null)
        {
            Destroy(spawnedWinnerModel);
        }

        if (winnerObject != null && winnerSpawnPoint != null)
        {
            spawnedWinnerModel = Instantiate(winnerObject, winnerSpawnPoint.position, Quaternion.identity);

            //DestroyImmediate(spawnedWinnerModel.GetComponent<PlayerHealth>());
            //DestroyImmediate(spawnedWinnerModel.GetComponent<Rigidbody2D>());
            //DestroyImmediate(spawnedWinnerModel.GetComponent<PlayerScript>());

            Destroy(spawnedWinnerModel.GetComponent<PlayerHealth>());
            Destroy(spawnedWinnerModel.GetComponent<Rigidbody2D>());
            Destroy(spawnedWinnerModel.GetComponent<PlayerScript>());
        }
    }
}

