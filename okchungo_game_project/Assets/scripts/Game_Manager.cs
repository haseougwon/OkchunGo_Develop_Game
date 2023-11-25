using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Game_Manager : MonoBehaviour
{
    public GameObject menu;
    public GameObject EffectVolumeGauge_1;
    public GameObject EffectVolumeGauge_2;
    public GameObject EffectVolumeGauge_3;
    public GameObject BgmVolumeGauge_1;
    public GameObject BgmVolumeGauge_2;
    public GameObject BgmVolumeGauge_3;
    public Text coin;
    public Text time;
    public Text stage;
    public GameObject canvaus;

    public void Start()
    {
        if (Data_controller.instance.nowPlayer.EffectVolume == 1f)
        {
            EffectVolumeGauge_1.SetActive(true);
            EffectVolumeGauge_2.SetActive(true);
            EffectVolumeGauge_3.SetActive(true);
        }
        else if (Data_controller.instance.nowPlayer.EffectVolume == 0.6f)
        {
            EffectVolumeGauge_2.SetActive(true);
            EffectVolumeGauge_3.SetActive(true);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0.3f)
        {
            EffectVolumeGauge_3.SetActive(true);
        }
        if (Data_controller.instance.nowPlayer.BgmVolume == 1.0f)
        {
            BgmVolumeGauge_1.SetActive(true);
            BgmVolumeGauge_2.SetActive(true);
            BgmVolumeGauge_3.SetActive(true);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0.6f)
        {
            BgmVolumeGauge_2.SetActive(true);
            BgmVolumeGauge_3.SetActive(true);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0.3f)
        {
            BgmVolumeGauge_3.SetActive(true);
        }
        Time.timeScale = 0;

    
        coin.text += "점수 :" + Data_controller.instance.nowPlayer.coin.ToString();
        time.text += "단계 :" + Data_controller.instance.nowPlayer.time.ToString();
        stage.text += Data_controller.instance.nowPlayer.stage.ToString() + "단계";
    }

    public void Update()
    {

        Data_controller.instance.nowPlayer.time += Time.deltaTime;
            time.text = "플레이시간:" + Data_controller.instance.nowPlayer.time.ToString("0.00");
        if (menu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void SettingClicked() {
        
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
            
        }
    }

    public void EffectVolumeClicked() {
        if (Data_controller.instance.nowPlayer.EffectVolume == 1f)
        {
            Data_controller.instance.nowPlayer.EffectVolume = 0.6f;
            EffectVolumeGauge_1.SetActive(false);
        }
        else if (Data_controller.instance.nowPlayer.EffectVolume == 0.6f)
        {
            Data_controller.instance.nowPlayer.EffectVolume = 0.3f;
            EffectVolumeGauge_2.SetActive(false);
        }
        else if (Data_controller.instance.nowPlayer.EffectVolume == 0.3f)
        {
            Data_controller.instance.nowPlayer.EffectVolume = 0f;
            EffectVolumeGauge_3.SetActive(false);          
        }
        else if (Data_controller.instance.nowPlayer.EffectVolume == 0f)
        {
            Data_controller.instance.nowPlayer.EffectVolume = 1f;
            EffectVolumeGauge_1.SetActive(true);
            EffectVolumeGauge_2.SetActive(true);
            EffectVolumeGauge_3.SetActive(true);
        }
    }
    public void BgmVolumeClicked()
    {
        if (Data_controller.instance.nowPlayer.BgmVolume == 1f)
        {
            Data_controller.instance.nowPlayer.BgmVolume = 0.6f;
            BgmVolumeGauge_1.SetActive(false);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0.6f)
        {
            Data_controller.instance.nowPlayer.BgmVolume = 0.3f;
            BgmVolumeGauge_2.SetActive(false);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0.3f)
        {
            Data_controller.instance.nowPlayer.BgmVolume = 0f;
            BgmVolumeGauge_3.SetActive(false);
        }
        else if (Data_controller.instance.nowPlayer.BgmVolume == 0f)
        {
            Data_controller.instance.nowPlayer.BgmVolume = 1f;
            BgmVolumeGauge_1.SetActive(true);
            BgmVolumeGauge_2.SetActive(true);
            BgmVolumeGauge_3.SetActive(true);

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
        SceneManager.LoadScene("TitleScene");
    }
    public void End() {
        Application.Quit();
    }

    public void CoinUp()
    {
        SceneMove sound = canvaus.GetComponent<SceneMove>();
        sound.ClickSound1();
        Data_controller.instance.nowPlayer.coin += 1;
        coin.text = "점수 :" + Data_controller.instance.nowPlayer.coin.ToString();
    }
}
