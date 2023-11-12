using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public GameObject menu;

    public void Start()
    {
        
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

    public void Save()
    {
        Data_controller.instance.SaveData();
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
