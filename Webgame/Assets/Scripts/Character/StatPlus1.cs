using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus1 : StatPlus
{
    public GameObject hpUp, hpDn, atkUp, atkDn, defUp, defDn, aglUp, aglDn;

    public void HpPlus()
    {
        if (characterStat1.maxUpgrade > 0)
        {
                characterStat1.hp++;
                for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                {
                    if (upgrade1[i] == null)
                    {
                        upgrade1[i] = "hp";
                        characterStat1.maxUpgrade--;
                        break;
                    }
                }
        }
    }

    public void HpMin()
    {
         if (characterStat1.maxUpgrade >= 0)
         {
                 for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
                 {
                     if (upgrade1[i] == "hp")
                     {
                         characterStat1.hp--;
                         upgrade1[i] = null;
                         characterStat1.maxUpgrade++;
                         break;
                     }
                 }
         }               
    }

    public void ATKPlus()
    {
        if (characterStat1.maxUpgrade > 0)
        {
            characterStat1.atk++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "atk";
                    characterStat1.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void ATKMin()
    {
        if (characterStat1.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "atk")
                {
                    characterStat1.atk--;
                    upgrade1[i] = null;
                    characterStat1.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void DEFPlus()
    {
        if (characterStat1.maxUpgrade > 0)
        {
            characterStat1.def++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "def";
                    characterStat1.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void DEFMin()
    {
        if (characterStat1.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "def")
                {
                    characterStat1.def--;
                    upgrade1[i] = null;
                    characterStat1.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void AGLPlus()
    {
        if (characterStat1.maxUpgrade > 0)
        {
            characterStat1.agl++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "agl";
                    characterStat1.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void AGLMin()
    {
        if (characterStat1.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "agl")
                {
                    characterStat1.agl--;
                    upgrade1[i] = null;
                    characterStat1.maxUpgrade++;
                    break;
                }
            }
        }
    }
}
