using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void Coin1()
    {       
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        transform.position = new Vector2(transform.position.x, transform.position.y * 1.5f);

        Destroy(gameObject, 0.5f);
    }
}
