using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTargeting : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        //the object will position itself to face the player and track it
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg - 270f;
        rb.rotation = angle;
        direction.Normalize();
    }
}
