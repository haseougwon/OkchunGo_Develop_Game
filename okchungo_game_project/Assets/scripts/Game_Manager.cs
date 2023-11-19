using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public GameObject menu;

    //�ؽ�Ʈ
    public Text coin;
    public Text time;
    public Text stage;

    public void Start()
    {
        Time.timeScale = 0;

        //�ܰ�,����,�ð� ǥ��
        coin.text += "���� :" + Data_controller.instance.nowPlayer.coin.ToString();
        time.text += "�÷��� �ð� :" + Data_controller.instance.nowPlayer.time.ToString();
        stage.text += Data_controller.instance.nowPlayer.stage.ToString() + "�ܰ�"; 
    }

    public void Update()
    {
            Data_controller.instance.nowPlayer.time += Time.deltaTime;
            time.text = "�÷��� �ð� :" + Data_controller.instance.nowPlayer.time.ToString("0.00");
        
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }

        if (menu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
    public void Save()
    {
        Data_controller.instance.SaveData();
    }

    public void Load()
    {
        SceneManager.LoadScene("select");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void CoinUp()
    {
        Data_controller.instance.nowPlayer.coin += 1;
        coin.text = "���� :" + Data_controller.instance.nowPlayer.coin.ToString();
    }
}
