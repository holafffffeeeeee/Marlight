using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;  // Assign the Audio Mixer here
    [SerializeField] private Slider mainSlider;  // Assign the UI slider here

    public void SetMainVolume()
    {
        float volume = mainSlider.value;  // Get the slider value
        myMixer.SetFloat("MainVolume", Mathf.Log10(volume) * 20);  // Set the mixer volume
    }
}
