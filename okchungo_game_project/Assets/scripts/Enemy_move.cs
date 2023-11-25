using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_move: MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider1;
    public int nextMove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider1 = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();
    }
    void LateUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 5);
        }
    }
    void Think()
    {
        float nextThink = Random.Range(2f, 5f);

        while (true)
        {
            nextMove = Random.Range(-1, 2);

            if (nextMove == 0)
            {
                nextMove = Random.Range(-1, 2);
            }
            else
            {
                break;
            }

        }

        Invoke("Think", nextThink);
    }


    public void OnDamaged()
    {
        CancelInvoke();

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        collider1.enabled = false;

        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        Destroy(gameObject, 5);

    }
}