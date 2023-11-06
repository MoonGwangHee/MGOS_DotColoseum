using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PartyType : MonoBehaviour
{
    public CharacterType    CharaType1, CharaType2, CharaType3;
    public int    hp1, atk1, def1, agl1;
    public int    hp2, atk2, def2, agl2;
    public int    hp3, atk3, def3, agl3;

}

public class ChangetoJson : MonoBehaviour
{
    CharacterStat first, second, third;
    private void Start()
    {
        first = CharaManager.instance.first.GetComponent<CharacterStat>();
        second = CharaManager.instance.second.GetComponent<CharacterStat>();
        third = CharaManager.instance.third.GetComponent<CharacterStat>();

        PartyType partyType = new PartyType()
        {
            CharaType1 =    CharaManager.instance.PlayerParty[0],
            hp1 =           first.hp,
            atk1 =          first.atk,
            def1 =          first.def,
            agl1 =          first.agl
        };

        string json = JsonUtility.ToJson(partyType);
        print(json);
    }
}