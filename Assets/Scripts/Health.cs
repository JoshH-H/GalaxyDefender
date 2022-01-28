using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{ 
    GlobalDataLvl1 gd;
    public float health = 120f;
    public int value = 0;
    public bool spawn;
    public GameObject spawner;
    public GameObject boom;
    
    void Update()
    {
        if(health <= 0f)
        {
            if (spawn)
            {
                GameObject.Instantiate(spawner, transform.position, Quaternion.identity);
            }
            GlobalDataLvl1.score += value;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl1>().SetScore();
            Destroy(gameObject);
            GameObject b = Instantiate(boom) as GameObject;
            b.transform.position = transform.position;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;

        }
    }

}
