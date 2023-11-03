using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NmaePopup : MonoBehaviour
{
    public Text memName1, memName2, memName3;
    public string defaultName = "New Text";
    void Start()
    {
        Debug.Log(memName1);
        Call1();
    }

    public void Call1()
    {
        for (int i = 0; i < 3; i++)
        {
            if (CharaManager.instance.PlayerParty[i] == CharacterType.Archer)
            {
                if (memName1.text == "New Text")
                    memName1.text = "궁수";
                else if (memName2.text == "New Text")
                    memName2.text = "궁수";
                else if (memName3.text == "New Text")
                    memName3.text = "궁수";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Knight)
            {
                if (memName1.text == "New Text")
                    memName1.text = "기사";
                else if (memName2.text == "New Text")
                    memName2.text = "기사";
                else if (memName3.text == "New Text")
                    memName3.text = "기사";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Mage)
            {
                if (memName1.text == "New Text")
                    memName1.text = "법사";
                else if (memName2.text == "New Text")
                    memName2.text = "법사";
                else if (memName3.text == "New Text")
                    memName3.text = "법사";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Rog)
            {
                if (memName1.text == "New Text")
                    memName1.text = "도적";
                else if (memName2.text == "New Text")
                    memName2.text = "도적";
                else if (memName3.text == "New Text")
                    memName3.text = "도적";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Mercenary)
            {
                if (memName1.text == "New Text")
                    memName1.text = "용병";
                else if (memName2.text == "New Text")
                    memName2.text = "용병";
                else if (memName3.text == "New Text")
                    memName3.text = "용병";
            }
        }

    }

}