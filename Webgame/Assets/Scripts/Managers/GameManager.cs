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
        // �̹� �����ϴ� ��� �ߺ� ������ ����
        if (instance == null)
        {
            instance = this; // �ڱ� �ڽ����� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �����ǵ��� ����
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

    public void PauseBtn()
    {
        Time.timeScale = 0;
    }

    public void PauseBackBtn()
    {
        Time.timeScale = 1f;
    }

}
