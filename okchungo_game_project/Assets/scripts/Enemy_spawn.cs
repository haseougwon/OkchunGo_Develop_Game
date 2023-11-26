using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_spawn : MonoBehaviour
{
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject[] enemy;
    public Transform target;

    void Start()
    {
    }

    void Update()
    {
        if (curTime >= spawnTime && Vector2.Distance(transform.position, target.position) <= 5)
        {
            SpawnEnemy();
        }
        curTime += Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy[0], spawnPoints[0]);
        Instantiate(enemy[1], spawnPoints[1]);
        Instantiate(enemy[2], spawnPoints[2]);
        curTime = 0;
    }
}
