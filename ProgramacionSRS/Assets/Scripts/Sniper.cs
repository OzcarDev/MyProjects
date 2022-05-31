using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    void Start()
    {
        InvokeRepeating("Shoot", 0, 2);
    }

  

    void Shoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
