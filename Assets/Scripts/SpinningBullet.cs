using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBullet : MonoBehaviour
{
    public GameObject bullet;
    public float rotateSpeed = 0f;
    
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.World);
    }
}
