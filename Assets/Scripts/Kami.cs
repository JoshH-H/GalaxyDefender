using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kami : MonoBehaviour
{
    public GameObject kami;
    public float kamirof;
    public float nextKami;
    
    void Start()
    {
        nextKami = Time.time;
    }
    
    private void Update()
    {
        TimeToFire();
    }
    
    void TimeToFire()
    {
        if (Time.time > nextKami)
        {
            Instantiate(kami, transform.position, Quaternion.identity);
            nextKami = Time.time + kamirof;
        }
    }


}
