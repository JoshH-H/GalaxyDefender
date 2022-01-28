using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovementNULL : MonoBehaviour
{
    public float horizontalMove = 0.4f;
    public float verticalMove = 0.4f;
    public GameObject bullet;
    public GameObject player;
    public AudioSource Fire;

    
    void Start()
    {
        
    }

    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * horizontalMove;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * horizontalMove;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * verticalMove;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * verticalMove;
        }

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
        //Fire;
    }
}
