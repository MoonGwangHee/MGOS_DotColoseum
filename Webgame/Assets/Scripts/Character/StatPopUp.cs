using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPopUp : MonoBehaviour
{

    private Text            statText; // 스테이터스를 나타내는 Text 컴포넌트
    public GameObject       prefab;    //프리펩 로드
    private CharacterStat   characterStat; 
    // 프리팹으로부터 Stats 클래스 가져오기

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
