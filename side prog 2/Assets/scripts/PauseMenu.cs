using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PauseMenu : MonoBehaviour

{
    public GameObject pauseMenu;
    public bool IsPuased;
    public void Start()
    {
        pauseMenu.SetActive(false);
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPuased = true;
    }
    public void ResumeGame()
    { pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPuased = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
  

}

