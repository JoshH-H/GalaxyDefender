using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private GlobalDataLvl1 gd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            GlobalDataLvl1.lives++;
            GameObject.Find("Manager").GetComponent<GlobalDataLvl1>().UpdateLives();
            Destroy(this.gameObject);
        }
    }
}
