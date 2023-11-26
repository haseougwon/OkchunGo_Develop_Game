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

    public void Boom()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}


