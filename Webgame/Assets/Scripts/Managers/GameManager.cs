using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        // �̹� �����ϴ� ��� �ߺ� ������ ����
        if (instance == null)
        {
            instance = this; // �ڱ� �ڽ����� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� ��� �ı�
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
        // ���� ���� �ε����� �����ͼ� �ش� ���� �ٽ� �ε�
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
