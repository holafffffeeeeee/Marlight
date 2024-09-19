using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;  // For TextMeshPro Dropdown


public class OptionsScript : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;  // Assign the Audio Mixer here
    [SerializeField] private Slider mainSlider;  // Assign the UI slider here
    [SerializeField] private Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;  // TMP Dropdown


    public void SetMainVolume()
    {
        float volume = mainSlider.value;  // Get the slider value
        myMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20);  // Set the mixer volume
    }
  
    private Resolution[] resolutions;

    private void Start()
    {
        // Get available resolutions and populate the dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Set the default option to the current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener for resolution change
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        // Set fullscreen toggle based on current screen mode
        fullscreenToggle.isOn = Screen.fullScreen;
        fullscreenToggle.onValueChanged.AddListener(SetFullScreen);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Back()
    {
        string previousScene = GameManager.Instance.previousScene;
        if (previousScene == "MainMenu")
        {
            // Go back to Main Menu
            GameManager.Instance.LoadScene("MainMenu");
        }
        else if (previousScene == "GameScene")
        {
            // Go back to Game Scene and set flag to pause on return
            GameManager.Instance.shouldPauseOnReturn = true;
            GameManager.Instance.LoadScene("GameScene");
        }
        else
        {
            Debug.LogWarning("Previous scene is not tracked or doesn't exist.");
        }
    }


}
