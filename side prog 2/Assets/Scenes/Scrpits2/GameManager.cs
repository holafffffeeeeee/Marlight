
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string previousScene;  // To track the previous scene
    public float masterVolume = 1.0f;
    public bool shouldPauseOnReturn = false;
    public float savedHealth;
    public float savedMana;
    public float savedStamina;
    public static GameManager instance;
    public bool hasSavedStats = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to load a scene and track the previous scene

    public void LoadScene(string sceneName)
    {
        // Track the current active scene before loading the new one
        previousScene = SceneManager.GetActiveScene().name;

        // Debug log to make sure the previousScene is set correctly
        Debug.Log("Setting previousScene to: " + previousScene);

        // Load the requested scene
        SceneManager.LoadScene(sceneName);
    }


    void Update()
    {
        // Check if we should pause when entering GameScene again
        if (SceneManager.GetActiveScene().name == "GameScene" && shouldPauseOnReturn)
        {
            PauseGame();
            shouldPauseOnReturn = false;  // Reset the flag
        }
    }

    public void PauseGame()
    {
        // Pausing logic, e.g., finding PauseMenu object and activating it
        UnifiedPauseMenu PauseMenuManager = FindObjectOfType<UnifiedPauseMenu>();
        if (PauseMenuManager != null)
        {
            PauseMenuManager.PauseGame();
        }
    }
    public void SavePlayerStats(PlayerStats playerStats)
    {
        savedHealth = playerStats.currentHealth;
        savedMana = playerStats.currentMana;
        savedStamina = playerStats.currentStamina;

        hasSavedStats = true;
    }

    // Call this to restore stats (after coming back to GameScene)
    public void RestorePlayerStats(PlayerStats playerStats)
    {
        if (hasSavedStats)
        {
            playerStats.currentHealth = savedHealth;
            playerStats.currentMana = savedMana;
            playerStats.currentStamina = savedStamina;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            // Restore the player stats when returning to the game scene
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats != null)
            {
                GameManager.Instance.RestorePlayerStats(playerStats);
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}