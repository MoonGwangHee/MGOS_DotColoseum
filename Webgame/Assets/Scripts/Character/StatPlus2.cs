using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus2 : StatPlus
{
    public GameObject hpUp, hpDn, atkUp, atkDn, defUp, defDn, aglUp, aglDn;

    public void HpPlus()
    {
        if (characterStat2.maxUpgrade > 0)
        {
            characterStat2.hp++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "hp";
                    characterStat2.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void HpMin()
    {
        if (characterStat2.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "hp")
                {
                    characterStat2.hp--;
                    upgrade1[i] = null;
                    characterStat2.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void ATKPlus()
    {
        if (characterStat2.maxUpgrade > 0)
        {
            characterStat2.atk++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "atk";
                    characterStat2.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void ATKMin()
    {
        if (characterStat2.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "atk")
                {
                    characterStat2.atk--;
                    upgrade1[i] = null;
                    characterStat2.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void DEFPlus()
    {
        if (characterStat2.maxUpgrade > 0)
        {
            characterStat2.def++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "def";
                    characterStat2.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void DEFMin()
    {
        if (characterStat2.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "def")
                {
                    characterStat2.def--;
                    upgrade1[i] = null;
                    characterStat2.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void AGLPlus()
    {
        if (characterStat2.maxUpgrade > 0)
        {
            characterStat2.agl++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "agl";
                    characterStat2.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void AGLMin()
    {
        if (characterStat2.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "agl")
                {
                    characterStat2.agl--;
                    upgrade1[i] = null;
                    characterStat2.maxUpgrade++;
                    break;
                }
            }
        }
    }
}
