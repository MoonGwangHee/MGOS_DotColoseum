using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Default,
    Mercenary,
    Archer,
    Rog,
    Knight,
    Mage
}

public class CharaManager : MonoBehaviour
{
    public static CharaManager              instance;
    public  GameObject[]                    charPrefabs;
    public bool                             instance1 = false,
                                            instance2 = false,
                                            instance3 = false;
    public GameObject                       first;
    public GameObject                       second;
    public GameObject                       third;
    public GameObject                       left;
    public GameObject                       right;
    public GameObject                       middle;
    public CharacterType[] PlayerParty = { 
                                            CharacterType.Default, 
                                            CharacterType.Default, 
                                            CharacterType.Default 
                                          };

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        //DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!instance1 || !instance2 || !instance3)
        {
            if (CharaManager.instance.PlayerParty[0] != CharacterType.Default && instance1 == false)
            {
                first = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[0] - 1]);
                first.transform.position = left.transform.position;
                instance1 = true;
            }
            else if (CharaManager.instance.PlayerParty[1] != CharacterType.Default && instance2 == false)
            {
                second = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[1] - 1]);
                second.transform.position = middle.transform.position;
                instance2 = true;
            }
            else if (CharaManager.instance.PlayerParty[2] != CharacterType.Default && instance3 == false)
            {
                third = Instantiate(charPrefabs[(int)CharaManager.instance.PlayerParty[2] - 1]);
                third.transform.position = right.transform.position;
                instance3 = true;
            }

        }

    }

    public void SendingPartyInfo()
    {
        PlayerPrefs.SetInt("Character1", (int)PlayerParty[0]);
        PlayerPrefs.SetInt("Character2", (int)PlayerParty[1]);
        PlayerPrefs.SetInt("Character3", (int)PlayerParty[2]);
        PlayerPrefs.Save();
    }

    public void PartyCancel1()
    {
        if (CharaManager.instance.PlayerParty[0] != CharacterType.Default)
        {
            CharaManager.instance.PlayerParty[0] = CharacterType.Default;
            instance1 = false;
            Destroy(first);
        }
    }
    public void PartyCancel2()
    {
        if (CharaManager.instance.PlayerParty[1] != CharacterType.Default)
        {
            CharaManager.instance.PlayerParty[1] = CharacterType.Default;
            instance2 = false;
            Destroy(second);
}
    }
    public void PartyCancel3()
    {
        if (CharaManager.instance.PlayerParty[2] != CharacterType.Default)
        {
            CharaManager.instance.PlayerParty[2] = CharacterType.Default;
            instance3 = false;
            Destroy(third);
        }
    }
        
        


}
