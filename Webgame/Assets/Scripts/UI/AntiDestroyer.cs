using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDestroyer : MonoBehaviour
{
    void Start()
    {
        // ������Ʈ�� �� ��ȯ �� �ı����� �ʵ��� ����
        DontDestroyOnLoad(this.gameObject);
    }
}
