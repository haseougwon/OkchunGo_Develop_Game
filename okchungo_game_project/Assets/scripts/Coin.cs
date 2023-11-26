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
    void ActivityOff() {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        if (Player_UI.isRestart == true) {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1.4f);
                spriteRenderer.color = new Color(0, 0, 0, 0.4f);
                Player_UI.isRestart = false;
            gameObject.SetActive(true);
        }

    }
    public void Coin1()
    {       
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        transform.position = new Vector2(transform.position.x, transform.position.y + 1.4f);

        Invoke("ActivityOff", 0.5f);
    }
}
