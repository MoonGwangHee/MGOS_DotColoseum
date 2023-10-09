using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivingPartyInfo : MonoBehaviour
{
    public CharacterType[] PlayerParty = new CharacterType[3];
    void Start()
    {
        PlayerParty[0] = (CharacterType)PlayerPrefs.GetInt("Character1");
        PlayerParty[1] = (CharacterType)PlayerPrefs.GetInt("Character2");
        PlayerParty[2] = (CharacterType)PlayerPrefs.GetInt("Character3");
    }
}
