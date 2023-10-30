using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPlus : MonoBehaviour
{
    CharacterStat charcterStat;

    public void StatReset()
    {
        //스테이터스를 원상태로 복귀시키고 UpgradeNum을 3으로 되돌리는 내용
    }

    public void HpPlus()
    {
        this.charcterStat.hp++;
    }
}
