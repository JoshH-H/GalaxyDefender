using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Transform point;
    private Vector2 movement;
    public float moveSpeed = 5f;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        point = GameObject.FindGameObjectWithTag("BossPoint").transform;
    }
    
    void Update() 
    {
        //look for the location of the player and point 
        Vector3 direction = player.position - transform.position;
        Vector3 direction2 = point.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg - 270f;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction2;
    }
    
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction2)
    {
        rb.MovePosition((Vector2)transform.position + (direction2 * moveSpeed * Time.deltaTime));
    }
}
