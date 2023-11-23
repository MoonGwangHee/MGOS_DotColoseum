using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeRunner : MonoBehaviour
{
    public Transform        target; // �̵��� ��ǥ ����
    public float            moveSpeed; // �̵� �ӵ�

    private void Update()
    {
        if (target != null)
        {
            // �÷��̾ ��ǥ ���� �������� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // �÷��̾ ��ǥ ������ �����ϸ� ��ǥ ������ null�� �����Ͽ� �̵��� ����
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
