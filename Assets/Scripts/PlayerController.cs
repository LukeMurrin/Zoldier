using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed;
    public GameObject camera;

    public GameObject PlayerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject Bullet;

    private Transform bulletSpawned;
    public float points;

    public float MaxHealth = 100;
    public float health;

    
    //Methods

    void start()
    {
        health = MaxHealth;
    }


    void Update()
    {

        //Player Facing Mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        //Player Movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //Player Death
        if(health < 0)
        {
           // Die();
        }
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(Bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

    /*public float Die()
    {
       
    }
    */

}
