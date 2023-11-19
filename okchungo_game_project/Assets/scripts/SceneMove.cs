using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private AudioSource AudioSource;
    public AudioClip ClickSound_1;
    public AudioClip ClickSound_2;
    public string scene;

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
    

    void Update()
    {
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(scene);
    }
    public void select()
    {
        ClickSound1();
        Invoke("SceneChange", 0.5f);

    }
    public void Setting()
    {
        
    }
}

