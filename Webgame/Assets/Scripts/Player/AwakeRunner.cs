using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRunner : MonoBehaviour
{
    public Transform        target; // 이동할 목표 지점
    public float            moveSpeed; // 이동 속도

    private void Update()
    {
        if (target != null)
        {
            // 플레이어를 목표 지점 방향으로 이동
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // 플레이어가 목표 지점에 도착하면 목표 지점을 null로 설정하여 이동을 멈춤
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
