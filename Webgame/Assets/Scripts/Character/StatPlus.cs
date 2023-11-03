using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus : MonoBehaviour
{
    CharacterStat charcterStat;

    string[] upgrade1 = new string[3];
    string[] upgrade2 = new string[3];
    string[] upgrade3 = new string[3];
    private CharacterStat[] Stats = new CharacterStat[3];

    public GameObject       hpUp, hpDn, atkUp, atkDn, defUp, defDn, aglUp, aglDn;
    private GameObject      prefab1, prefab2, prefab3;
    private CharacterStat   characterStat1, characterStat2, characterStat3;

    private void Start()
    {
        prefab1 = CharaManager.instance.first;
        prefab2 = CharaManager.instance.second;
        prefab3 = CharaManager.instance.third;
        characterStat1 = prefab1.GetComponent<CharacterStat>();
        characterStat2 = prefab2.GetComponent<CharacterStat>();
        characterStat3 = prefab3.GetComponent<CharacterStat>();

        Stats[0] = characterStat1;
        Stats[1] = characterStat2;
        Stats[2] = characterStat3;
    }


    public void HpPlus()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade > 0)
            {
                switch (hpUp.gameObject.name)
                {
                    case "hpUp1":
                        
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == null)
                            {
                                characterStat1.hp++;
                                upgrade1[j] = "hp";
                                Stats[i].maxUpgrade--;
                                characterStat1.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "hpUp2":
                        characterStat2.hp++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == null)
                            {
                                upgrade2[j] = "hp";
                                characterStat2.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "hpUp3":
                        characterStat3.hp++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == null)
                            {
                                upgrade3[j] = "hp";
                                characterStat3.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (hpUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }

    }
    public void HpMin()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade >= 0)
            {
                switch (hpUp.gameObject.name)
                {
                    case "hpUp1":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == "hp")
                            {
                                characterStat1.hp--;
                                upgrade1[j] = null;
                                characterStat1.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "hpUp2":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == "hp") //한번이라도 이 스탯을 선택했다면 실행
                            {
                                characterStat2.hp--;
                                upgrade2[j] = null;
                                characterStat2.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "hpUp3":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == "hp")
                            {
                                characterStat3.hp--;
                                upgrade3[j] = null;
                                characterStat3.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (hpUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
        
    }
    public void ATKPlus()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade > 0)
            {
                switch (atkUp.gameObject.name)
                {
                    case "atkUp1":

                        characterStat1.atk++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == null)
                            {
                                upgrade1[j] = "atk";
                                characterStat1.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "atkUp2":

                        characterStat2.atk++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == null)
                            {
                                upgrade2[j] = "atk";
                                characterStat2.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "atkUp3":
                        characterStat3.atk++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == null)
                            {
                                upgrade3[j] = "atk";
                                characterStat3.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (atkUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
    }
    public void ATKMin()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade >= 0)
            {
                switch (atkUp.gameObject.name)
                {
                    case "atkUp1":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == "atk")
                            {
                                characterStat1.atk--;
                                upgrade1[j] = null;
                                characterStat1.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "atkUp2":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == "atk") //한번이라도 이 스탯을 선택했다면 실행
                            {
                                characterStat2.atk--;
                                upgrade2[j] = null;
                                characterStat2.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "atkUp3":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == "atk")
                            {
                                characterStat3.atk--;
                                upgrade3[j] = null;
                                characterStat3.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (atkUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
    }
    public void DEFPlus()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade > 0)
            {
                switch (defUp.gameObject.name)
                {
                    case "defUp1":

                        characterStat1.def++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == null)
                            {
                                upgrade1[j] = "def";
                                characterStat1.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "defUp2":

                        characterStat2.def++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == null)
                            {
                                upgrade2[j] = "def";
                                characterStat2.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                    case "defUp3":
                        characterStat3.def++;
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == null)
                            {
                                upgrade3[j] = "def";
                                characterStat3.maxUpgrade--;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (defUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
    }
    public void DEFMin()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade >= 0)
            {
                switch (defUp.gameObject.name)
                {
                    case "defUp1":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == "def")
                            {
                                characterStat1.def--;
                                upgrade1[j] = null;
                                characterStat1.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "defUp2":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == "def") //한번이라도 이 스탯을 선택했다면 실행
                            {
                                characterStat2.def--;
                                upgrade2[j] = null;
                                characterStat2.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "defUp3":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == "def")
                            {
                                characterStat3.def--;
                                upgrade3[j] = null;
                                characterStat3.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (defUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
    }
    public void AGLPlus()
    {
        if (characterStat1.maxUpgrade > 0)
        {
            for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
            {
                if (Stats[i].maxUpgrade > 0)
                {
                    switch (aglUp.gameObject.name)
                    {
                        case "aglUp1":

                            characterStat1.agl++;
                            for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                            {
                                if (upgrade1[j] == null)
                                {
                                    upgrade1[j] = "agl";
                                    characterStat1.maxUpgrade--;
                                    break;
                                }
                            }
                            break;
                        case "aglUp2":

                            characterStat2.agl++;
                            for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                            {
                                if (upgrade2[j] == null)
                                {
                                    upgrade2[j] = "agl";
                                    characterStat2.maxUpgrade--;
                                    break;
                                }
                            }
                            break;
                        case "aglUp3":
                            characterStat3.agl++;
                            for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                            {
                                if (upgrade3[j] == null)
                                {
                                    upgrade3[j] = "agl";
                                    characterStat3.maxUpgrade--;
                                    break;
                                }
                            }
                            break;
                    }
                }
            }
            if (aglUp.gameObject.name == null)
            {
                Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
            }
        }
    }
    public void AGLMin()
    {
        for (int i = 0; i < 3; i++) //파티창 세 칸을 한번씩 도는 for문
        {
            if (Stats[i].maxUpgrade >= 0)
            {
                switch (aglUp.gameObject.name)
                {
                    case "aglUp1":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade1[j] == "agl")
                            {
                                characterStat1.agl--;
                                upgrade1[j] = null;
                                characterStat1.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "aglUp2":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade2[j] == "agl") //한번이라도 이 스탯을 선택했다면 실행
                            {
                                characterStat2.agl--;
                                upgrade2[j] = null;
                                characterStat2.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                    case "aglUp3":
                        for (int j = 0; j < 3; j++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                        {
                            if (upgrade3[j] == "agl")
                            {
                                characterStat3.agl--;
                                upgrade3[j] = null;
                                characterStat3.maxUpgrade++;
                                break;
                            }
                        }
                        break;
                }
            }
        }
        if (aglUp.gameObject.name == null)
        {
            Debug.Log("게임오브젝트에 값이 들어가 있지 않음");
        }
    }


}
