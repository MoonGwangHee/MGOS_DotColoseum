using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePartyName : MonoBehaviour
{
    public InputField               userInputField; // Inspector 창에서 Input Field를 연결할 변수
    public string                   partyName; // 입력값을 저장할 변수

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 이 스크립트가 연결된 GameObject를 씬 전환 시에 파괴하지 않도록 설정
    }

    public void SaveInputText()
    {
    partyName = userInputField.text;
    }
}
