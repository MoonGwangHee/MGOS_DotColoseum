using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRunner : MonoBehaviour
{
    public float moveSpeed; // 이동 속도

    private void Update()
    {
        // 현재 오브젝트의 위치를 가져옴
        Vector3 currentPosition = transform.position;

        // 오른쪽으로 이동
        currentPosition.x += moveSpeed * Time.deltaTime;

        transform.position = currentPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            GameObject targetObject = GameObject.Find("Player");

            if (targetObject != null)
            {
                // 현재 위치를 가져옴
                Vector3 newPosition = targetObject.transform.position;

                // 새로운 z 값을 설정
                newPosition.z = 0;

                // 위치를 변경
                targetObject.transform.position = newPosition;
            }
        }
    }
}
