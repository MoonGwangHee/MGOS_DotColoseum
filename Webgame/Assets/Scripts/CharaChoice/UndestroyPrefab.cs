using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndestroyPrefab : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
