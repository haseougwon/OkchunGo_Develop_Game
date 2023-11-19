using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player_move : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public int jumpCount;
    int jumpCut;
    [SerializeField] 
    float cheakRadius;
    public int absoluteTime;
    public bool isAbsoluteTime = false;
    public GameObject Object;

    bool isPlatform;

    [SerializeField] LayerMask mask; 
    [SerializeField] Transform pos;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        jumpCut = jumpCount;
    }


    private void Update()
    {
        Vector2 frontVec = new Vector2(rigid.position.x, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down * 0.55f, new Color(0, 1, 0));
        RaycastHit2D isPlatform = Physics2D.Raycast(frontVec, Vector3.down, 0.55f, LayerMask.GetMask("Platform"));

        if (isPlatform == true && Input.GetButtonUp("Jump") && jumpCut > 0)
        {
            rigid.velocity = Vector2.up * jumpPower;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpCut--;
        }
        if (isPlatform == false && Input.GetButtonUp("Jump") && jumpCut > 0)
        {
            rigid.velocity = Vector2.up * jumpPower;
        }
        if (isPlatform)
        {
            jumpCut = jumpCount;
        }

        if (Input.GetButtonUp("Horizontal"))
        {

            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
     
        if (Input.GetButton("Horizontal"))
        {

            spriteRenderer.flipX = (Input.GetAxisRaw("Horizontal") == -1);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isRun", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("isRun", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("isRun", true);
        }

        if (Input.GetButtonDown("Jump")) {
            anim.SetTrigger("doJump");
        }
    }

    void FixedUpdate()
    {
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
            {
                OnDamaged(collision.transform.position);
            }
        }

        //폭발 범위 확인
        if (collision.gameObject.tag == "boom")
        {
            OnDamaged(collision.transform.position);
        }
    }


    void OnAttack(Transform enemy)
    {

        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Enemy_move enemyMove = enemy.GetComponent<Enemy_move>();
        enemyMove.OnDamaged();

    }

    public void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;

        spriteRenderer.color = new Color(1,1,1,0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)* 10, ForceMode2D.Impulse);
        Invoke("OffDamaged", absoluteTime);
        
    }
    void OffDamaged()
    {
        gameObject.layer = 10;

        spriteRenderer.color = new Color(1, 1, 1, 1);
        isAbsoluteTime = false;
    }

    //코인 충돌 확인
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            //점수 증가
            Object.GetComponent<Game_Manager>().CoinUp();

            //코인 삭제 모션
            Coin coin2 = collision.gameObject.GetComponent<Coin>();
            coin2.Coin1();
        }

        
    }

   
}