using UnityEngine;

public class UnifiedPauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;   // Reference to the pause menu UI in the scene
    private bool isPaused = false;

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);   // Ensure the pause menu is hidden at the start
        }
        else
        {
            Debug.LogError("Pause Menu UI is not assigned!");
        }
    }

    void Update()
    {
        // Toggle pause when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);    // Show the pause menu
            Time.timeScale = 0f;            // Freeze the game
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);   // Hide the pause menu
            Time.timeScale = 1f;            // Resume the game
            isPaused = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
