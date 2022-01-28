using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public EnemyBullet bullet;
    public GameObject playerTransform;
    
    public float RoF;
    public float nextShot;


    void Start()
    {
        nextShot = Time.time;
    }

    private void Update()
    {
        TimeToFire();
    }

    void TimeToFire()
    {
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);

            nextShot = Time.time + RoF;
        }
    }
}
