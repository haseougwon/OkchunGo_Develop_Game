using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {

            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
     
        if (Input.GetButtonDown("Horizontal"))
        {
            
            spriteRenderer.flipX = (Input.GetAxisRaw("Horizontal") == -1);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isRun", false);
            anim.SetTrigger("Standing");

        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isRun", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

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
}
