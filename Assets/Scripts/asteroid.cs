using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds; 
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }
    
    void Update()
    {
        //when the object is out of the frame, it will delete
        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if collided with the player, access the health in the manager and deduct 1 life 
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);            
            GlobalDataLvl1.lives--;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl1>().UpdateLives();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //enemies can destroy asteroids to clear a path to the player
        if (collision.gameObject.tag == ("EnemyBullet"))
        {
            Destroy(this.gameObject);
        }

    }
}
