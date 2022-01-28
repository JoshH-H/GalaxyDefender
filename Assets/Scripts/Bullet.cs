using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float damage = 34f;
    private float speed = 50.0f;
    private Vector2 screenBounds;
    public GameObject asteroid;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when the player bullet collides with different tagged objects, it will destroy itself to reduce objects on screen
        if (collision.gameObject.tag == ("Boss1"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Boss2")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == ("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == ("asteroid"))
        {
            Destroy(this.gameObject);
        }    
    }
}

