using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager           instance;
    public GameObject                   warning;
    public CharacterPool                pool;

    private void Awake()
    {
        // 이미 존재하는 경우 중복 생성을 방지
        if (instance == null)
        {
            instance = this; // 자기 자신으로 설정
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지되도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 경우 파괴
        }
    }

    IEnumerator SceneChangeDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Battle");
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

}
