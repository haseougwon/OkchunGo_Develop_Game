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

    //텍스트
    public Text coin;
    public Text time;
    public Text stage;

    public void Start()
    {
        Time.timeScale = 0;

        //단계,점수,시간 표시
        coin.text += "점수 :" + Data_controller.instance.nowPlayer.coin.ToString();
        time.text += "플레이 시간 :" + Data_controller.instance.nowPlayer.time.ToString();
        stage.text += Data_controller.instance.nowPlayer.stage.ToString() + "단계"; 
    }

    public void Update()
    {
            Data_controller.instance.nowPlayer.time += Time.deltaTime;
            time.text = "플레이 시간 :" + Data_controller.instance.nowPlayer.time.ToString("0.00");
        
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
        coin.text = "점수 :" + Data_controller.instance.nowPlayer.coin.ToString();
    }
}
