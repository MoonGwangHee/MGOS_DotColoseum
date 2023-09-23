using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager   instance;
    public AudioMixer           mixer;


    IEnumerator SceneChangeDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Choice");
    }

    public void SceneChange()
    {
        StartCoroutine(SceneChangeDelay());
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;
    }

    public void PauseBackBtn()
    {
        Time.timeScale = 1f;
    }

    public void SetBGM(float sliderValue)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSE(float sliderValue)
    {
        mixer.SetFloat("SE", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMaster(float sliderValue)
    {
        mixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
    }
}
