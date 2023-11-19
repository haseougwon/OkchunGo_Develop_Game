using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Sense : MonoBehaviour
{
    public bool player = false;
    public GameObject Object;
    SpriteRenderer spriteRenderer;
    Collider col;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Object.GetComponent<Enemy_Explosive>().Sensing();
        }  
    }

    public void Boom()
    {
        this.gameObject.tag = "boom";

        spriteRenderer.color = new Color(1, 1, 1, 1);
        Object.GetComponent<Enemy_Explosive>().stop();

}
}
