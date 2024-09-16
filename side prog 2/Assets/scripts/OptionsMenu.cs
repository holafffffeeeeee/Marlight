using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;

    // Start is called before the first frame update

    // Called when "Options" button is clicked
    public void OpenOptions()
    {

        PauseMenu.SetActive(false);    // Hide pause menu
    }

    // Called when "Back" button in options menu is clicked
    public void CloseOptions()
    {

        PauseMenu.SetActive(true);     // Show pause menu again
    }

    // Pauses the game
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;  // Stop time
    }

    // Resumes the game
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;  // Resume time
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            // Find objects in the new scene, e.g., player, UI, etc.
            GameObject Pausemenu = GameObject.Find("PauseMenu");
            Debug.Log("Game Scene loaded and player found: " + pausemenu.name);
        }
    }
}