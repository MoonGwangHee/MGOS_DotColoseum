using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager   instance;
    public GameObject           warning;
    CharacterStat _first, _second, _third;

    IEnumerator SceneChangeDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Choice");
    }

    public void SceneChange()
    {
        StartCoroutine(SceneChangeDelay());
    }

    public void SceneChange2()
    {
        if (CharaManager.instance.PlayerParty[0] != CharacterType.Default &&
           CharaManager.instance.PlayerParty[1] != CharacterType.Default &&
           CharaManager.instance.PlayerParty[2] != CharacterType.Default)
            StartCoroutine(SceneChangeDelay2());
        else
        {
            warning.SetActive(true);
            Time.timeScale = 0;
        }
            
    }

    IEnumerator SceneChangeDelay2()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Status");
    }

    public void SceneChange3()
    {
        _first = CharaManager.instance.first.GetComponent<CharacterStat>();
        _second = CharaManager.instance.second.GetComponent<CharacterStat>();
        _third = CharaManager.instance.third.GetComponent<CharacterStat>();

        if (_first.maxUpgrade == 0 && _second.maxUpgrade == 0 && _third.maxUpgrade == 0)
            StartCoroutine(SceneChangeDelay3());
        else
        {
            warning.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void SceneChange3Go()
    {
        StartCoroutine(SceneChangeDelay3());
    }

    IEnumerator SceneChangeDelay3()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("Enemy");
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
