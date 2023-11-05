using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public int jumpCount;
    int jumpCut;
    [SerializeField] float cheakRadius;
    public int absoluteTime;

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
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isJump", true);
            }
            else
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isJump", false);
            }
        }
        else
        {

            anim.SetBool("isRun", false);
            anim.SetBool("isRun", true);
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
    }

    void OnAttack(Transform enemy)
    {
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Enemy_move enemyMove = enemy.GetComponent<Enemy_move>();
        enemyMove.OnDamaged();
    }
    
    void OnDamaged(Vector2 targetPos)
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
    }
}