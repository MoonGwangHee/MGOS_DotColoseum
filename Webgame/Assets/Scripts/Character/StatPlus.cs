using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus : MonoBehaviour
{
    CharacterStat charcterStat;

    protected string[] upgrade1 =                 new string[3];
    protected string[] upgrade2 =                 new string[3];
    protected string[] upgrade3 =                 new string[3];
    protected GameObject                          prefab1, prefab2, prefab3;
    protected CharacterStat                       characterStat1, characterStat2, characterStat3;

    private void Start()
    {
        prefab1 =                               CharaManager.instance.first;
        prefab2 =                               CharaManager.instance.second;
        prefab3 =                               CharaManager.instance.third;
        characterStat1 =                        prefab1.GetComponent<CharacterStat>();
        characterStat2 =                        prefab2.GetComponent<CharacterStat>();
        characterStat3 =                        prefab3.GetComponent<CharacterStat>();
    }


    


}
