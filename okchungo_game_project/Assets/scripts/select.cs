using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject creat;	
    public Text[] slotText;		
    public Text newPlayerName;	

    bool[] savefile = new bool[3];	

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(Data_controller.instance.path + $"{i}"))	
            {
                savefile[i] = true;		
                Data_controller.instance.nowSlot = i;	
                Data_controller.instance.LoadData();	
                slotText[i].text = Data_controller.instance.nowPlayer.name;	
            }
            else	
            {
                slotText[i].text = "비어있음";
            }
        }
        Data_controller.instance.DataClear();
    }

    public void Slot(int number)	
    {
        Data_controller.instance.nowSlot = number;	

        if (savefile[number])	
        {
            Data_controller.instance.LoadData();	
            GoGame();	
        }
        else	
        {
            Creat();	
        }
    }

    public void Creat()	
    {
        creat.gameObject.SetActive(true);
    }

    public void GoGame()	
    {
        if (!savefile[Data_controller.instance.nowSlot])	
        {
            Data_controller.instance.nowPlayer.name = newPlayerName.text; 
            Data_controller.instance.SaveData();
        }
        SceneManager.LoadScene("stage_1");
        Time.timeScale = 1;
    }
}