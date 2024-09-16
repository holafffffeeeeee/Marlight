using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes
using UnityEngine.UI; // Needed for UI elements

public class MainMenuController : MonoBehaviour
{
    public bool IsPuased;
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with your actual game scene name
    }

    public void OpenOptions()
    {
        // Load the options menu scene
        SceneManager.LoadScene("OptionsMenu"); // Replace with your actual options scene name
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene("GameScene");
        IsPuased = false;
    }
}