using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_move : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }

    void LateUpdate()
    {
        //¿òÁ÷ÀÓ
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //³¶¶³¾îÁö È®ÀÎ
        Vector2 frontVec =  new Vector2 (rigid.position.x + nextMove*0.3f, rigid.position.y);
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
        
        //·£´ý °ª 0¹æÁö
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
}
