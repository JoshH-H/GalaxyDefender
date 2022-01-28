using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveL2 : MonoBehaviour
{
    private float horizontalMove = 0.15f;
    private float verticalMove = 0.15f;

    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * horizontalMove;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * horizontalMove;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * verticalMove;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * verticalMove;
        }
    }

}

