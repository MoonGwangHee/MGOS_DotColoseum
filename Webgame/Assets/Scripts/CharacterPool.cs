using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    public GameObject[]             skills;
    public List<GameObject>[]       pools;

    private void Awake()
    {
        pools = new List<GameObject>[skills.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        } 
    }

    public GameObject GetSkills(int i)
    {
        GameObject select = null;

        //비활성화된 (사용하지않고 저장해놓은) 스킬에 접근
        foreach(GameObject item in pools[i])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(skills[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
