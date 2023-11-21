using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;
public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    //����ȭ
    //public���� �������� �ʾƵ� ����Ƽ inspector â���� ������ ������ �����ϰ���
    [SerializeField]
    private Transform                   playerTransform;
    [SerializeField]
    private Vector3                     cameraPosition;

    [SerializeField]
    public Vector2                      center;

    [SerializeField]
    public Vector2                      mapSize;

    [SerializeField]
    private float                       cameraMoveSpeed;
    private float                       height;
    public float                        width;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Player��� �̸��� ���ӿ�����Ʈ �˻� �� Transform ������Ʈ ��������
        playerTransform =   GameObject.Find("Player").GetComponent<Transform>();

        //ī�޶��� ���߾ӿ��� ���� ������ �������� ����(=������ ����)
        height =            Camera.main.orthographicSize;
        //ī�޶� ���� * ���� �ػ󵵿� ���� ���� ũ�� / ���� �ػ󵵿� ���� ���� ũ��
        //��, ī�޶� ���߾ӿ��� ���α����� �������� ����(=�ʺ��� ����)
        width =             height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);

        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    //ī�޶� �̵����ɱ��� Ȯ���� ���� �ڵ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
