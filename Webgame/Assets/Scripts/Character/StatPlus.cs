using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus : MonoBehaviour
{
    CharacterStat charcterStat;

    public void StatReset()
    {
        //�������ͽ��� �����·� ���ͽ�Ű�� UpgradeNum�� 3���� �ǵ����� ����
    }

    public void HpPlus()
    {
        this.charcterStat.hp++;
    }
}
