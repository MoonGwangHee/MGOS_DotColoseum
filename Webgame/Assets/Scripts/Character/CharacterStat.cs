using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public CharacterType    type;

    public int              atk = 0;
    public int              def = 0;
    public int              agl = 0;
    public int              hp = 0;
    public int              upgradeNum = 3;
    public void Awake()
    {
        DefaultStatSetting();

        void DefaultStatSetting()
        {
            if (type == CharacterType.Archer)
            {
                hp = 4;
                atk = 6;
                def = 4;
                agl = 6;

            }
            else if (type == CharacterType.Mage)
            {
                hp = 2;
                atk = 9;
                def = 4;
                agl = 4;
            }
            else if (type == CharacterType.Mercenary)
            {
                hp = 5;
                atk = 5;
                def = 5;
                agl = 5;
            }
            else if (type == CharacterType.Rog)
            {
                hp = 4;
                atk = 3;
                def = 3;
                agl = 8;
            }
            else if (type == CharacterType.Knight)
            {
                hp = 9;
                atk = 2;
                def = 7;
                agl = 2;
            }
        }
    }

    

    

}
