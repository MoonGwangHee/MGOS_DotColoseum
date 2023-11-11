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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == null)
                {
                    upgrade3[i] = "hp";
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == "hp")
                {
                    characterStat3.hp--;
                    upgrade3[i] = null;
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == null)
                {
                    upgrade3[i] = "atk";
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == "atk")
                {
                    characterStat3.atk--;
                    upgrade3[i] = null;
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == null)
                {
                    upgrade3[i] = "def";
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == "def")
                {
                    characterStat3.def--;
                    upgrade3[i] = null;
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == null)
                {
                    upgrade3[i] = "agl";
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
            for (int i = 0; i < 3; i++) //��Ƽâ �Ѹ��� ���׷��̵� �迭�� ������ ����
            {
                if (upgrade3[i] == "agl")
                {
                    characterStat3.agl--;
                    upgrade3[i] = null;
                    characterStat3.maxUpgrade++;
                    break;
                }
            }
        }
    }
}