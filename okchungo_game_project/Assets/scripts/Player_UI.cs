using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;



public class Player_UI : MonoBehaviour
{
    int heart = 3;
    public GameObject heart_1;
    public GameObject heart_2;
    public GameObject heart_3;
    private AudioSource audioSource;
    public AudioClip BackGroundSound;
    public GameObject gameoverMenu;
    public Text coin;
    public Text stage;
    public Text time;
    SpriteRenderer spriteRenderer;
    public static bool isRestart;

    Rigidbody2D rigid;
    GameObject obj;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isRestart = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        if (heart == 3)
        {
            heart_1.SetActive(true);
            heart_2.SetActive(true);
            heart_3.SetActive(true);
        }
        else if (heart == 2)
        {

            heart_1.SetActive(false);
        }
        else if (heart == 1)
        {
            heart_1.SetActive(false);
            heart_2.SetActive(false);

        }
        else if (heart == 0)
        {
            heart_1.SetActive(false);
            heart_2.SetActive(false);
            heart_3.SetActive(false);
            GameOver();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.layer == 11)
            {
                if (heart == 3)
                {
                    heart = 2;
                }
                else if (heart == 2)
                {
                    heart = 1;
                }
                else if (heart == 1)
                {
                    heart = 0;

                }
            }
        }
        if (collision.gameObject.layer == 7) 
        {
            heart = 0;
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
        Time.timeScale = 0;
        gameoverMenu.SetActive(true);
        coin.text = "점수 :" + Data_controller.instance.nowPlayer.coin.ToString();
        stage.text = "최종 스테이지 :"+Data_controller.instance.nowPlayer.stage.ToString() + "단계";

    }
    public void again() {
        gameoverMenu.SetActive(false);
        if (Data_controller.instance.nowPlayer.stage == 1)
        {
            Data_controller.instance.nowPlayer.coin = 0;
            SceneManager.LoadScene("stage_1");
        }
        else if (Data_controller.instance.nowPlayer.stage == 2)
        {
            SceneManager.LoadScene("stage_2");
        }
        else if (Data_controller.instance.nowPlayer.stage == 2)
        {
            SceneManager.LoadScene("stage_3");
        }
    }
    
}
