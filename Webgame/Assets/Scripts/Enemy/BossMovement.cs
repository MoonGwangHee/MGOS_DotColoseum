using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float            maxSpeed;
    public float            jumpPower;
    public GameObject       magicalHands;
    public GameObject       Slime;
    private Transform       playerTransform;
    public float            moveSpeed;
    bool                    first = true;
    public int              bossHp;
    public int              maxBossHp;
    GameObject              playerObject;
    public Transform        atkBoxMiddle;
    public Vector2          atkBoxSize;
    public Animation        animationComponent;
    Rigidbody2D             rigid;
    SpriteRenderer          sprite;
    Animator                animator;
    new CapsuleCollider2D   collider;
    public  MagicalHand     hand;

    public Transform[]      slimeSpawnPoints;

    public GameObject       winPanel;

    private void Awake()
    {
        maxBossHp = 12;
        bossHp = 12;
        moveSpeed = 1.2f;
        first = true;
        animationComponent = GetComponent<Animation>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();

        Invoke("Think", 1f);
    }

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        StartCoroutine(ThinkCoroutine());
    }
    private void Update()
    {
        if (playerTransform != null)
        {
            ChasePlayer();
            
        }

        if (bossHp <= 0)
        {
            animator.SetTrigger("onDead");
            StartCoroutine(Byebye());
        }
    }

    void ChasePlayer()
    {
        animator.SetBool("isWalk", true);

        float targetX = playerTransform.position.x;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        float xDifference = Mathf.Abs(playerTransform.position.x - transform.position.x);

        // 플레이어 방향으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 플레이어가 왼쪽에 있으면 스프라이트를 반전
        if (targetX > transform.position.x +2)
        {

            // 현재 스케일이 변동되지 않았을 때만 반전
            if (transform.localScale.x > 0)
            {
                // x축 스케일은 -1로 유지, y축 스케일은 1로 유지
                transform.localScale = new Vector3(-5.6f, 5.6f, 1);
                transform.position = new Vector3(transform.position.x + 3.3f, transform.position.y, transform.position.z);

            }
        }
        // 플레이어가 오른쪽에 있으면 스프라이트를 원래대로
        else if (targetX < transform.position.x -2)
        {
            // 현재 스케일이 변동되지 않았을 때만 원래대로
            if (transform.localScale.x < 0)
            {
                // x축 스케일은 1로 유지, y축 스케일은 1로 유지
                transform.localScale = new Vector3(5.6f, 5.6f, 1);
                transform.position = new Vector3(transform.position.x - 3.3f, transform.position.y, transform.position.z);
            }
        }
        if (xDifference < 2 && xDifference > -2)
            animator.SetBool("isWalk", false);
    }

    public void BossTakeDamage()
    {
        animator.SetTrigger("damageOn");
        int randomDmg = 1;
        bossHp -= randomDmg;
    }

    void Think()
    {
        float xDifference = Mathf.Abs((playerTransform.position.x-1) - (transform.position.x+2));
        if(xDifference <= 4.5f && first == false)
        {
            
            animator.SetTrigger("atkOn");
            
            Debug.Log("1");
        }
        if (xDifference > 4.5f && first == false)
        {
            int nextSpell = Random.Range(0, 10);

            if(nextSpell <= 7) 
            {//주문
                animator.SetTrigger("spellOn"); Debug.Log("2");
            }
            else if(nextSpell > 7)
            { //쫄 소환
                animator.SetTrigger("summonOn"); Debug.Log("3");
            }
        }
        first = false;
    }

    IEnumerator ThinkCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            Think();
        }
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

    public void ActiveMagicHand() {
        magicalHands.SetActive(true);
        Vector2 newPosition = magicalHands.transform.position;
        newPosition.x = playerTransform.position.x;

        magicalHands.transform.position = newPosition;
    }

    public void SpawnSlimes()
    {
        for(int i=0; i<2; i++)
            Instantiate(Slime, slimeSpawnPoints[i]);
    }

    IEnumerator Byebye()
    {
        yield return new WaitForSeconds(2f);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
    void OnDrawGizmos()
    {
        // 기즈모로 거리를 시각적으로 표시
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");


        float startX = transform.position.x;

        // 플레이어 오브젝트의 x 좌표
        float endX = playerObject.transform.position.x;

        if (playerObject != null)
        {
            // 선을 그릴 두 점의 위치를 지정
            Vector3 start = new Vector3(startX, -5, transform.position.z);
            Vector3 end = new Vector3(endX, -5, playerObject.transform.position.z);
            Gizmos.color = Color.red;
            // 선을 그림
            Gizmos.DrawLine(start, end);
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(atkBoxMiddle.position, atkBoxSize);
    }
}
