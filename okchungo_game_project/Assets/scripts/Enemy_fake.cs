using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_fake : MonoBehaviour
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

        if (Vector2.Distance(transform.position, target.position) < 8)
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
        if(i)
        {
            player = true;
            i = false;
        }
    }

    public void boom()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
        player = false;
        cir.GetComponent<Sense>().Boom();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = false;
            spriteRenderer.color = new Color(1, 1, 1, 0);
            cir.GetComponent<Sense>().Boom();
            Destroy(gameObject,1);
        }
    }
}
