using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject menu;
    public GameObject EffectVolumeGauge_1;
    public GameObject EffectVolumeGauge_2;
    public GameObject EffectVolumeGauge_3;
    public GameObject BgmVolumeGauge_1;
    public GameObject BgmVolumeGauge_2;
    public GameObject BgmVolumeGauge_3;

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
    }

    public void Update()
    {
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
        Debug.Log(Data_controller.instance.nowPlayer.EffectVolume);
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

    public void GameExit()
    {
        Application.Quit();
    }
}
