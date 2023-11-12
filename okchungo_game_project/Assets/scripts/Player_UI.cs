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
   
    
    Rigidbody2D rigid;
    GameObject obj;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        obj = GameObject.Find("Player");

    }
  
    void OnCollisionEnter2D(Collision2D collision) {
   
        if (collision.gameObject.tag == "Enemy") {
            if (gameObject.layer == 11)
            {
                Debug.Log("����");
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

    void GameOver() {
    
    }
}
