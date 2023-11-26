using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private AudioSource AudioSource;
    public AudioClip ClickSound_1;


    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    public void ClickSound1()
    {
        AudioSource.clip = ClickSound_1;
        AudioSource.volume = Data_controller.instance.nowPlayer.EffectVolume;
        AudioSource.Play();
    }
    

    public void SceneChange()
    {
        SceneManager.LoadScene("select");
    }

    public void Select()
    {
        ClickSound1();
        Invoke("SceneChange", 0.5f);
    }

}

