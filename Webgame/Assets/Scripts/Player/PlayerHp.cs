using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    public BossMovement     boss;
    public PlayerMovement   player;
    Transform               fillArea;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "BossBar")
            hpBar.maxValue = boss.maxBossHp;
        if (name == "PlayerBar")
            hpBar.maxValue = player.maxPlayerHp;

    }

    // Update is called once per frame
    void Update()
    {
        if (name == "BossBar")
        {
            hpBar.value = boss.bossHp;
        }

        if (name == "PlayerBar")
        {
            hpBar.value = player.playerHp;
        }

        if(player.playerHp <= 0)
        {
            fillArea = hpBar.transform.Find("Fill Area");
            fillArea.gameObject.SetActive(false);
        }
            

    }
}
