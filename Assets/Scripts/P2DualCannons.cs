using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2DualCannons : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public AudioSource Fire;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootyTime();
        }
    }
    //Shooting
    public void ShootyTime()
    {
        GameObject b =Instantiate(bullet) as GameObject;
        b.transform.position = player.transform.position;
        Fire.Play();
    }
}
