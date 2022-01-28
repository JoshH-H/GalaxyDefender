using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFire : MonoBehaviour
{
    public KamiAttack missile;
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
            Instantiate(missile, transform.position, Quaternion.identity);

            nextShot = Time.time + RoF;
        }
    }
}
