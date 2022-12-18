using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    //Variables
    public float health;
    public float pointsToGive;
    private GameObject Player;
    private Rigidbody enemy;
    public Transform target;
    public float speed;
    public float withinRange;
    public delegate void enemyKilled();
    public static event enemyKilled OnEnemyKilled;



    public GameObject player;


    //Methods
    public void Start()
    {
        enemy = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if(dist <= withinRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position ,speed);
        }

        if(health <= 0)
        {
            Die();
        }

       

    }

    public void Die()
    {

        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }

        Destroy(this.gameObject);

        player.GetComponent<PlayerController>().points += pointsToGive;

    }

}
