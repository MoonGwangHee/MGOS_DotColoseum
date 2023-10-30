using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPopUp : MonoBehaviour
{

    private Text            statText; // �������ͽ��� ��Ÿ���� Text ������Ʈ
    public GameObject       prefab;    //������ �ε�
    private CharacterStat   characterStat; 
    // ���������κ��� Stats Ŭ���� ��������

    private void Start()
    {
        statText =     GetComponent<Text>();

        prefab =        CharaManager.instance.first;
        characterStat = prefab.GetComponent<CharacterStat>();

        if (characterStat != null)
        {
            UpdatePowerText();
        }
        else
        {
            Debug.LogWarning("CharacterStat component not found on the prefab.");
        }
    }
    private void UpdatePowerText()
    {
        if (characterStat != null)
        {
            statText.text = "HP: " + characterStat.hp.ToString() + "\n" +
                            "ATK: " + characterStat.atk.ToString() +"\n" +
                            "DEF: " + characterStat.def.ToString() +"\n" +
                            "AGL: " + characterStat.agl.ToString();
        }
    }
}
