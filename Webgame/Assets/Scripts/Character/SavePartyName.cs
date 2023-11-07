using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePartyName : MonoBehaviour
{
    public InputField               userInputField; // Inspector â���� Input Field�� ������ ����
    public string                   partyName; // �Է°��� ������ ����

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // �� ��ũ��Ʈ�� ����� GameObject�� �� ��ȯ �ÿ� �ı����� �ʵ��� ����
    }

    public void SaveInputText()
    {
    partyName = userInputField.text;
    }
}
