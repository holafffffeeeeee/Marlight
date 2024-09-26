using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
   
{
    private PlayerStats playerStats;
    public GameObject PauseMenu;
    public bool IsPuased;
    public void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        PauseMenu.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPuased)
            {
                ResumeGame();
            }
            else
            {
                PuaseGame();
            }
        }
    }
    public void PuaseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPuased = true;
    }
    public void ResumeGame()
    { 
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPuased = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
   

}

