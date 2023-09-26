using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartySpawn : MonoBehaviour
{
    public GameObject[] charPrefabs;
    public bool         instance1 = false, 
                        instance2 = false, 
                        instance3 = false;
    public GameObject          first;
    public GameObject          second;
    public GameObject          third;
    public GameObject          left;
    public GameObject          right;
    public GameObject          middle;

    void Update()
    {
        if(!instance1 || !instance2 || !instance3)
        {
            if (CharaManager.instance.PlayerParty[0] != CharacterType.Default && instance1 == false)
            {
                first = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[0]-1]);
                first.transform.position = left.transform.position;
                instance1 = true;
            }
            else if (CharaManager.instance.PlayerParty[1] != CharacterType.Default && instance2 == false)
            {
                second = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[1]]);
                second.transform.position = middle.transform.position;
                instance2 = true;
            }
            else if (CharaManager.instance.PlayerParty[2] != CharacterType.Default && instance3 == false)
            {
                third = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[2]]);
                third.transform.position = right.transform.position;
                instance3 = true;
            }

        }

    }
}
