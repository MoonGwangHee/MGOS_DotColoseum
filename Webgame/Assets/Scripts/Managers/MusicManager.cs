using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioMixer          mixer;

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
