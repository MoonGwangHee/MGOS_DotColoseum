using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager  instance;
    public AudioMixer           mixer;
    public Slider               slider;

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if(currentScene == "Start")
        {
            PlayerPrefs.SetFloat("BGMValue", slider.value);
            PlayerPrefs.SetFloat("SEValue", slider.value);
            PlayerPrefs.SetFloat("MasterValue", slider.value);
        }
        
    }
    public void SetBGM(float sliderValue)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMValue", sliderValue);
        PlayerPrefs.Save();
    }
    public void SetSE(float sliderValue)
    {
        mixer.SetFloat("SE", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SEValue", sliderValue);
        PlayerPrefs.Save();
    }
    public void SetMaster(float sliderValue)
    {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterValue", sliderValue);
        PlayerPrefs.Save();
    }
}
