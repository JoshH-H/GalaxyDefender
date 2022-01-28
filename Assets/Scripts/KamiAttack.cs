using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamiAttack : MonoBehaviour
{
    private GlobalDataLvl1 gd;
    public GameObject Boom;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject b = Instantiate(Boom) as GameObject;
            b.transform.position = transform.position;
            GlobalDataLvl1.lives--;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl1>().UpdateLives();
            Destroy(this.gameObject);
        }
    }
}
