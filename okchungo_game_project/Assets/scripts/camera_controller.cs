using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    GameObject player;
    void Awake()
    {
        this.player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        Vector3 playerpos = this.player.transform.position;
        transform.position = new Vector3(playerpos.x, playerpos.y,transform.position.z);
    }
}
