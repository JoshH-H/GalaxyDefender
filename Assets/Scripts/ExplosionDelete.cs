using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDelete : MonoBehaviour
{
    public float timer = 0f;
    void Start()
    {
        StartCoroutine("DeleteMe");
    }

    IEnumerator DeleteMe()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }


}
