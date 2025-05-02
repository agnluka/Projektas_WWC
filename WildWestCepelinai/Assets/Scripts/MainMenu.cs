using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneControl _sceneController;
    public void PlayGame()
    {
        _sceneController.LoadScene("Customization");
        //SceneManager.LoadScene("Customization");
    }

    public void OpenSettings()
    {
        _sceneController.LoadScene("Options");
        //SceneManager.LoadScene("Options");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}