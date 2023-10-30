using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiDestory : MonoBehaviour
{
    public static AntiDestory instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
