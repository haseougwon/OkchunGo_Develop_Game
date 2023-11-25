using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;


public class Player_UI : MonoBehaviour
{
    int heart = 3;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    private AudioSource audioSource;
    public AudioClip BackGroundSound;

    Rigidbody2D rigid;
    GameObject obj;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();


    }
  
    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.layer == 11)
            {
                Debug.Log("¡¢√À");
                if (heart == 3)
                {
                    heart = 2;
                    heart_1.SetActive(false);
                }
                else if (heart == 2)
                {
                    heart = 1;
                    heart_2.SetActive(false);
                }
                else if (heart == 1)
                {
                    heart = 0;
                    heart_3.SetActive(false);

                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "heart":
                    if (heart == 3)
                    {
                        break;
                    }
                    else if (heart == 2)
                    {
                        heart += 1;
                        heart_1.SetActive(true);
                    }
                    else if (heart == 1)
                    {
                        heart += 1;
                        heart_2.SetActive(true);
                    }
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    void GameOver() {
    
    }
}
