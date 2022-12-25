using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnBall;
    private Vector3[] spawnPosition = new Vector3[3] { new Vector3(-2, 7, 0), new Vector3(0, 7, 0), new Vector3(2, 7, 0) };
    private float startDelay = 1;
    private float spawnDelay = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, spawnDelay);
    }

    void SpawnObstacle()
    {
        if (!GameManager.endGame)
        {
            int rnd = Random.Range(0, spawnPosition.Length);
            Instantiate(spawnBall, spawnPosition[rnd], spawnBall.transform.rotation);
        }
    }
}