using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalHand : MonoBehaviour
{
    public Transform atkBoxMiddle;
    public Vector2 atkBoxSize;

    public void HideHand()
    {
        gameObject.SetActive(false);
    }

    public void ShowHand()
    {
        gameObject.SetActive(true);
    }

    public void GiveDmgPlayer()
    {
        Collider2D[] collider2D = Physics2D.OverlapBoxAll(atkBoxMiddle.position, atkBoxSize, 0);
        foreach (Collider2D item in collider2D)
        {
            if (item.tag == "Player")
                item.GetComponent<PlayerMovement>().PlayerTakeDamage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(atkBoxMiddle.position, atkBoxSize);
    }
}
