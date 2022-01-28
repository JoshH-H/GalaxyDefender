using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletL2 : MonoBehaviour
{ 
    GlobalDataLvl1 gd;
    Rigidbody2D rb;
    private float speed = 7.0f;
    private Transform Player;
    private Vector2 target;
    private Vector2 screenBounds;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    
    void Update()
    {

        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x==target.x  && transform.position.y == target.y )
        {
            Destroy(this.gameObject);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            GlobalDataLvl1.lives--;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl1>().UpdateLives();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("asteroid"))
        {
            Destroy(this.gameObject);
        }
    }

}
