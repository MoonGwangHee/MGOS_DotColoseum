using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAnim : MonoBehaviour
{
    float time;
    public float _fadeTime = 3f;
    new AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void FadeOut()
    {
        while(true)
        {
            if (time < _fadeTime)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 3f - time / _fadeTime);
            }
            else
            {
                time = 0;
                this.gameObject.SetActive(false);
                break;
            }
            time += Time.deltaTime;
        }
        
    }

    public void Audio()
    {
        audio.Play();
    }

}
