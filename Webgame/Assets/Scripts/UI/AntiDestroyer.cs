using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDestroyer : MonoBehaviour
{
    void Start()
    {
        // 오브젝트를 씬 전환 시 파괴되지 않도록 설정
        DontDestroyOnLoad(this.gameObject);
    }
}
