using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    GameObject          A;
    public GameObject   playerObject;
    public int          slimeHp = 1;
    public float        moveSpeed;
    private Transform   playerTransform;
    Animator            animator;
    Rigidbody2D rigid;

    private void Awake()
    {
        A = GameObject.FindGameObjectWithTag("Explosion");
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        moveSpeed = 1.6f;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (playerTransform != null)
        {
            ChasePlayer();
        }

        if(slimeHp <= 0)
        {
            animator.SetTrigger("onDeath");
            StartCoroutine(Byebye());
        }

        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 3, LayerMask.GetMask("Ground"));

        if (rayHit.collider != null)
        {
            if (rayHit.distance < 0.5f)
            {
                animator.SetBool("isIdle", false);
            }
        }

    }

    void ChasePlayer()
    {

        float targetX = playerTransform.position.x;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        float xDifference = Mathf.Abs(playerTransform.position.x - transform.position.x);

        // �÷��̾� �������� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // �÷��̾ ���ʿ� ������ ��������Ʈ�� ����
        if (targetX < transform.position.x)
        {

            // ���� �������� �������� �ʾ��� ���� ����
            if (transform.localScale.x > 0)
            {
                // x�� �������� -1�� ����, y�� �������� 1�� ����
                transform.localScale = new Vector3(-1f, 1f, 1);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            }
        }
        // �÷��̾ �����ʿ� ������ ��������Ʈ�� �������
        else if (targetX > transform.position.x)
        {
            // ���� �������� �������� �ʾ��� ���� �������
            if (transform.localScale.x < 0)
            {
                // x�� �������� 1�� ����, y�� �������� 1�� ����
                transform.localScale = new Vector3(1f, 1f, 1);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("onDeath");
            playerObject.GetComponent<PlayerMovement>().PlayerTakeDamage();
            StartCoroutine(Byebye());
        }
            
    }

    IEnumerator Byebye()
    {
        yield return new WaitForSeconds(0.4f);

        Destroy(gameObject);
    }
    public void SlimeTakeDamage()
    {
        animator.SetTrigger("onDeath");
        int randomDmg = 1;
        slimeHp -= randomDmg;
    }
}
