using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMeteors : MonoBehaviour
{
    public GameObject asteroidPre;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(meteorWave());
    }

    private void spawnMeteor()
    {
        GameObject a = Instantiate(asteroidPre) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator meteorWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnMeteor();
        }

    }
}
