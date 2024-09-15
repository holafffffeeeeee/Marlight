using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    
    // Called when "Options" button is clicked
    public void OpenOptions()
    {
      
        pauseMenu.SetActive(false);    // Hide pause menu
    }

    // Called when "Back" button in options menu is clicked
    public void CloseOptions()
    {
        
        pauseMenu.SetActive(true);     // Show pause menu again
    }

    // Pauses the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;  // Stop time
    }

    // Resumes the game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;  // Resume time
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            // Find objects in the new scene, e.g., player, UI, etc.
            GameObject pausemenu = GameObject.Find("pauseMenu");
            Debug.Log("Game Scene loaded and player found: " + pausemenu.name);
        }
    }
}