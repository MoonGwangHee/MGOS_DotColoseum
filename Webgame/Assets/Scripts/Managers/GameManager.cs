using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        // 이미 존재하는 경우 중복 생성을 방지
        if (instance == null)
        {
            instance = this; // 자기 자신으로 설정
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

    IEnumerator SceneReturneDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        GameObject A = GameObject.Find("BGsound");
        A.SetActive(false);
        SceneManager.LoadScene("Start");
    }

    public void SceneReturn()
    {
        StartCoroutine(SceneReturneDelay());
    }

    public void RestartScene()
    {
        // 현재 씬의 인덱스를 가져와서 해당 씬을 다시 로드
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
