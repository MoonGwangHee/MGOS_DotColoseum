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
                    memName1.text = "�ü�";
                else if (memName2.text == "New Text")
                    memName2.text = "�ü�";
                else if (memName3.text == "New Text")
                    memName3.text = "�ü�";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Knight)
            {
                if (memName1.text == "New Text")
                    memName1.text = "���";
                else if (memName2.text == "New Text")
                    memName2.text = "���";
                else if (memName3.text == "New Text")
                    memName3.text = "���";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Mage)
            {
                if (memName1.text == "New Text")
                    memName1.text = "����";
                else if (memName2.text == "New Text")
                    memName2.text = "����";
                else if (memName3.text == "New Text")
                    memName3.text = "����";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Rog)
            {
                if (memName1.text == "New Text")
                    memName1.text = "����";
                else if (memName2.text == "New Text")
                    memName2.text = "����";
                else if (memName3.text == "New Text")
                    memName3.text = "����";
            }
            else if (CharaManager.instance.PlayerParty[i] == CharacterType.Mercenary)
            {
                if (memName1.text == "New Text")
                    memName1.text = "�뺴";
                else if (memName2.text == "New Text")
                    memName2.text = "�뺴";
                else if (memName3.text == "New Text")
                    memName3.text = "�뺴";
            }
        }

    }

}