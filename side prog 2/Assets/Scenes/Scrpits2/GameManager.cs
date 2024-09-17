
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    // Example game-wide variables


    public float masterVolume = 1.0f;

    void Awake()
    {
        // Ensure there's only one GameManager and it persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
}   }