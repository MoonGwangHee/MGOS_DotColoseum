using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public CharacterType character;

    public void PartyPlus()
    {
        if (CharaManager.instance.PlayerParty[0] == CharacterType.Default)
            CharaManager.instance.PlayerParty[0] = character;
        else if (CharaManager.instance.PlayerParty[1] == CharacterType.Default)
            CharaManager.instance.PlayerParty[1] = character;
        else if (CharaManager.instance.PlayerParty[2] == CharacterType.Default)
            CharaManager.instance.PlayerParty[2] = character;
    }
}
