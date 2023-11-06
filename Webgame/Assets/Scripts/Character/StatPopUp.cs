using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPopUp : MonoBehaviour
{
    public Text             statText1, statText2, statText3; // �������ͽ��� �̸��� ��Ÿ���� Text ������Ʈ
    public Text[] memNames = new Text[3];
    public GameObject       prefab1, prefab2, prefab3;    //������ �ε�
    private CharacterStat   characterStat1, characterStat2, characterStat3;
    // ���������κ��� Stats Ŭ���� ��������

    private void Update()
    {
        UpdateText();
    }
    private void Start()
    {

        prefab1 =           CharaManager.instance.first;
        prefab2 =           CharaManager.instance.second;
        prefab3 =           CharaManager.instance.third;
        characterStat1 =    prefab1.GetComponent<CharacterStat>();
        characterStat2 =    prefab2.GetComponent<CharacterStat>();
        characterStat3 =    prefab3.GetComponent<CharacterStat>();

        UpdateText();
        UpdateName();
    }
    private void UpdateText()
    {
            statText1.text = "Level up: " + characterStat1.maxUpgrade.ToString() + "\n" +
                            "HP: " + characterStat1.hp.ToString() + "\n" +
                            "ATK: " + characterStat1.atk.ToString() +"\n" +
                            "DEF: " + characterStat1.def.ToString() +"\n" +
                            "AGL: " + characterStat1.agl.ToString();
            statText2.text = "Level up: " + characterStat2.maxUpgrade.ToString() + "\n" +
                            "HP: " + characterStat2.hp.ToString() + "\n" +
                            "ATK: " + characterStat2.atk.ToString() + "\n" +
                            "DEF: " + characterStat2.def.ToString() + "\n" +
                            "AGL: " + characterStat2.agl.ToString();
            statText3.text = "Level up: " + characterStat3.maxUpgrade.ToString() + "\n" +
                            "HP: " + characterStat3.hp.ToString() + "\n" +
                            "ATK: " + characterStat3.atk.ToString() + "\n" +
                            "DEF: " + characterStat3.def.ToString() + "\n" +
                            "AGL: " + characterStat3.agl.ToString();
    }
    private void UpdateName()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (CharaManager.instance.PlayerParty[i])
            {
                case CharacterType.Archer:
                    memNames[i].text = "�ü�";
                    break;
                case CharacterType.Knight:
                    memNames[i].text = "���";
                    break;
                case CharacterType.Mage:
                    memNames[i].text = "����";
                    break;
                case CharacterType.Rog:
                    memNames[i].text = "����";
                    break;
                case CharacterType.Mercenary:
                    memNames[i].text = "�뺴";
                    break;
            }
        }
    }
}
