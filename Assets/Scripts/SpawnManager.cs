using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    

    //Methods
    void Start()
    {
        SpawnNewEnemy();
    }

    void OnEnable()
    {
        Enemy.OnEnemyKilled += SpawnNewEnemy;
    }

    void SpawnNewEnemy()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length - 1));
        Instantiate(enemyPrefab, spawnPoints[randomNumber].transform.position, Quaternion.identity);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }
}
