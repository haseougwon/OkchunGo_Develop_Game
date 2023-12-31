using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Explosive : MonoBehaviour
{
    
    Rigidbody2D rigid;
    public Transform target;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public GameObject cir;

    bool i = true;
    bool player = false;
    public float maxSpeed;

    void Start()
    {     
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (player)
        {
            Vector3 dir = target.position - transform.position;

            transform.position += dir * maxSpeed * Time.deltaTime;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }

        if(Vector2.Distance(transform.position, target.position) < 4)
        {
            Sensing();
        }
    }

    public void Sensing()
    {
        rigid.gravityScale = 0;
        anim.SetBool("boom", true);
        Invoke("move", 1);
    }

    public void move()
    {
        if (i)
        {
            player = true;
            Invoke("boom", 3);
            i = false;
        }
    }

    public void stop()
    {
        player = false;
        
        Destroy(gameObject, 1);
    }

    public void boom()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
        cir.GetComponent<Sense>().Boom();

        if (Vector2.Distance(transform.position, target.position) < 1.5f)
        {
            target.GetComponent<player_move>().OnDamaged(transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = false;
            spriteRenderer.color = new Color(1, 1, 1, 0);
            cir.GetComponent<Sense>().Boom();
            target.GetComponent<player_move>().OnDamaged(collision.transform.position);
            Destroy(gameObject,0.5f);
        }
    }
}
