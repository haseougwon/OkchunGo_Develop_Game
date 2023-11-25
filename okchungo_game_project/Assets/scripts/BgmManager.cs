using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public AudioClip BackGroundSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackGroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        audioSource.volume = Data_controller.instance.nowPlayer.BgmVolume;
    }
}
