using UnityEngine;
using UnityEngine.SceneManagement;

public class UnifiedPauseMenu : MonoBehaviour
{
    private PlayerStats playerStats;
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
            Debug.Log("get ");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Debug.Log("else puase");
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
       
        if (pauseMenuUI != null)

        {
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            GameManager.Instance.SavePlayerStats(playerStats);
        }
            Debug.Log("puase game");

            pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
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
    public void OpenOptionsMenu()
    {
        // Save player stats before changing the scene
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            GameManager.Instance.SavePlayerStats(playerStats);
        }

        // Load the options menu
        GameManager.Instance.LoadScene("OptionsMenu");
    }

}
