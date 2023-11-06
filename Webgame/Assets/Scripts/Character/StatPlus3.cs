using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus3 : StatPlus
{
    public GameObject hpUp, hpDn, atkUp, atkDn, defUp, defDn, aglUp, aglDn;

    public void HpPlus()
    {
        if (characterStat3.maxUpgrade > 0)
        {
            characterStat3.hp++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "hp";
                    characterStat3.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void HpMin()
    {
        if (characterStat3.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "hp")
                {
                    characterStat3.hp--;
                    upgrade1[i] = null;
                    characterStat3.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void ATKPlus()
    {
        if (characterStat3.maxUpgrade > 0)
        {
            characterStat3.atk++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "atk";
                    characterStat3.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void ATKMin()
    {
        if (characterStat3.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "atk")
                {
                    characterStat3.atk--;
                    upgrade1[i] = null;
                    characterStat3.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void DEFPlus()
    {
        if (characterStat3.maxUpgrade > 0)
        {
            characterStat3.def++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "def";
                    characterStat3.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void DEFMin()
    {
        if (characterStat3.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "def")
                {
                    characterStat3.def--;
                    upgrade1[i] = null;
                    characterStat3.maxUpgrade++;
                    break;
                }
            }
        }
    }

    public void AGLPlus()
    {
        if (characterStat3.maxUpgrade > 0)
        {
            characterStat3.agl++;
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == null)
                {
                    upgrade1[i] = "agl";
                    characterStat3.maxUpgrade--;
                    break;
                }
            }
        }
    }

    public void AGLMin()
    {
        if (characterStat3.maxUpgrade >= 0)
        {
            for (int i = 0; i < 3; i++) //파티창 한명의 업그레이드 배열을 세번씩 돌림
            {
                if (upgrade1[i] == "agl")
                {
                    characterStat3.agl--;
                    upgrade1[i] = null;
                    characterStat3.maxUpgrade++;
                    break;
                }
            }
        }
    }
}
