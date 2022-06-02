using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int startSpawning;
    public int spawningRate;
    void Start()
    {
        InvokeRepeating("Spawn", startSpawning, spawningRate);  
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

   
}
