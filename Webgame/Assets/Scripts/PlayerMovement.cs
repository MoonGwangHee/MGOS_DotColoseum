using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float        maxSpeed;
    public float        jumpPower;

    private float       dashSpeed;
    private float       dashDuration;
    private bool        canMove;
    private float       dashTime;
    private bool        dashCool;
    private float       cutTime;

    public int          playerHp;
    public int          maxPlayerHp;
    public Transform    atkBoxMiddle;
    public Vector2      atkBoxSize;

    public GameObject   losePanel;
    GameObject          boss;
    public Animation    animationComponent;
    Rigidbody2D         rigid;
    SpriteRenderer      sprite;
    Animator            animator;
    CapsuleCollider2D   collider;
    public AudioSource  audioSource;

    private void Awake()
    {
        boss = GameObject.Find("Bringer Of Death");

        maxSpeed = 7f;
        dashSpeed = 11f;
        dashDuration = 1f;
        canMove = true;
        dashCool = false;
        playerHp = 5;
        maxPlayerHp = 5;
        GameObject layer = GameObject.Find("Player_Invincible");
        animationComponent = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //�����
        if(playerHp <= 0)
        {
            animator.SetTrigger("onDead");
            StartCoroutine(Byebye());
        }

        //���ݸ��
        if (cutTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                if (animator.GetBool("isDash"))
                {
                    animator.SetTrigger("dashAtkOn");
                }
                else
                {
                    animator.SetTrigger("atkOn");
                }
            }
        }
        else
        {
            cutTime -= Time.deltaTime;
        }

        //�����뽬
        if (Input.GetKeyDown(KeyCode.X) && canMove && dashCool == false)
        {
            dashCool = true;
            StartCoroutine(Dash());
        }

        //���� �ִϸ��̼� ����
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJump") && !animator.GetBool("isJumpDown"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            if (rigid.velocity.normalized.y > 0)
            {
                animator.SetBool("isJump", true);
            }
        }
        //���� �ִϸ��̼� ����
        if (rigid.velocity.normalized.y < 0)
        {
            animator.SetBool("isJumpDown", true);
        }

        //�ȱ� �ִϸ��̼� ����
        if (rigid.velocity.normalized.x == 0)
            animator.SetBool("isWalk", false);
        else if (rigid.velocity.normalized.x != 0)
        {
            animator.SetBool("isWalk", true);
        }
            

        //��ư �� ������ �ӵ� ���߱�
        if (Input.GetButtonUp("Horizontal"))
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        //�¿����
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = Mathf.Abs(currentScale.x) * Mathf.Sign(horizontalInput);
            transform.localScale = currentScale;
        }
    }

    private void FixedUpdate()
    {

        //�ȱ� ȿ�� ����
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //�ִ� �ӷ� ����
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

        else if(rigid.velocity.x < -maxSpeed)
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);


        //�ʷϻ� ���ٱ�(Ray)�� Ground�±׿� �����ϸ� ���� ��� = �����ϰ� idle/run���� ���ƿ���
        if (rigid.velocity.normalized.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 3, LayerMask.GetMask("Ground"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.3f)
                {
                    animator.SetBool("isJump", false);
                    animator.SetBool("isJumpDown", false);
                }
            }
        }
        
    }


   

    //���ο� �ǰ�����
    public void PlayerTakeDamage()
    {
        if (gameObject.layer == 10)
        {

        }
        else
        {
            Vector2 positionBoss = boss.transform.position;

            // �÷��̾��� ���� ��ġ�� ������
            Vector2 playerPosition = transform.position;

            // �÷��̾�� ������ ��ġ�� ���Ͽ� �÷��̾ ƨ��� ������ ����
            int direction = playerPosition.x > positionBoss.x - 3 ? -1 : 1;

            // OnDamaged �Լ� ȣ�� �� ƨ��� ������ ����
            OnDamaged(playerPosition, direction);

            // ������ ����
            int randomDmg = 1;
            playerHp -= randomDmg;
        }
        
    }

    void OnDamaged(Vector2 playerPos, int direction)
    {
        animator.SetBool("isDamaged", true);
        gameObject.layer = 10;

        sprite.color = new Color(1, 1, 1, 0.4f);

        // �÷��̾ ƨ��� ���⿡ ���� ���� ����
        rigid.AddForce(new Vector2(direction * 30, 10), ForceMode2D.Impulse);
        Invoke("OffDamaged", 1f);
    }
    public void OffDamaged()
    {
        //�� ���� �����ð� ���� (=�����ð� �� 0.7��)
        sprite.color = new Color(1, 1, 1, 1);
        gameObject.layer = 7;
    }

    public void ForCoolTime()
    {
        dashCool = false;
        Debug.Log("�뽬�� ����");
    }

    private IEnumerator Dash()
    {
        //�뽬�ӵ� �ִ�ġ 50(������ ����)
        maxSpeed = 11f;

        gameObject.layer = 10;
        canMove = false;
        animator.SetBool("isDash", true);
        dashTime = dashDuration;

        // ���� �ٶ󺸴� �������� ����
        int dashDirection = (int)Mathf.Sign(transform.localScale.x);
        rigid.velocity = new Vector2(dashDirection * dashSpeed, rigid.velocity.y);

        while (dashTime > 0)
        {
            //y��ǥ �����ϰ� �̵�
            float initialY = transform.position.y;

            dashTime -= Time.deltaTime;
            yield return null;

            Vector3 newPosition = transform.position;
            newPosition.y = initialY;
            transform.position = newPosition;
        }
        gameObject.layer = 7;
        // �뽬 ����
        canMove = true;
        animator.SetBool("isDash", false);
        maxSpeed = 7f;
        yield return new WaitForSeconds(0.43f);

        Invoke("ForCoolTime", 1f);
    }

    void DmgToEnemy()
    {
        Collider2D[] collider2D = Physics2D.OverlapBoxAll(atkBoxMiddle.position, atkBoxSize, 0);
        foreach (Collider2D item in collider2D)
        {
            if (item.tag == "Enemy")
            {
                item.GetComponent<BossMovement>().BossTakeDamage();
            }
            else if(item.tag == "Slime")
            {
                item.GetComponent<SlimeAI>().SlimeTakeDamage();
            }
        }
    }

    public void DmgOffAnime()
    {
        animator.SetBool("isDamaged", false);
    }

    IEnumerator Byebye()
    {
        yield return new WaitForSeconds(2f);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    //���ݹ��� �ð�ȭ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(atkBoxMiddle.position, atkBoxSize);
    }

}
