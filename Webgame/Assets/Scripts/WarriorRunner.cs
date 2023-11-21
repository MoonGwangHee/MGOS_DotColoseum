using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRunner : MonoBehaviour
{
    public float moveSpeed; // �̵� �ӵ�

    private void Update()
    {
        // ���� ������Ʈ�� ��ġ�� ������
        Vector3 currentPosition = transform.position;

        // ���������� �̵�
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
                // ���� ��ġ�� ������
                Vector3 newPosition = targetObject.transform.position;

                // ���ο� z ���� ����
                newPosition.z = 0;

                // ��ġ�� ����
                targetObject.transform.position = newPosition;
            }
        }
    }
}
