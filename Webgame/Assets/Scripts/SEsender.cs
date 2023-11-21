using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEsender : MonoBehaviour
{
    public AudioClip[] SE;
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource 컴포넌트 추가
        audioSource = gameObject.AddComponent<AudioSource>();

        
    }
    void PlayerWalkSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[0];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void PlayerAtkSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[1];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void PlayerDeathSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[2];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void PlayerDashSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[3];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void PlayerHurtSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[4];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void EnemyHandMagicSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[5];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void EnemyAtkSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[6];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void SlimeAtkSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[7];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void EnemySummonMagicSound()
    {
        if (audioSource != null)
        {
            audioSource.clip = SE[8];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void StopSound()
    {
        // AudioSource를 멈추고 재생 위치를 초기화
        audioSource.Stop();
        audioSource.time = 0f;
    }
}
