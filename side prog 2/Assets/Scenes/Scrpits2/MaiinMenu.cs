using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes


public class MainMenuController : MonoBehaviour
{
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
       
    }
}