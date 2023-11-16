using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIconSpawner : MonoBehaviour
{
    int maxIcon = 4;
    int nowIcon = 0;

    private void Update()
    {
        if(nowIcon < maxIcon)
        {
            for (int i = 0; i < maxIcon; i++)
            {
                GameManager.instance.pool.GetSkills(i);
                nowIcon++;

                if (nowIcon >= maxIcon)
                    break;
            }
        }
    }
}
