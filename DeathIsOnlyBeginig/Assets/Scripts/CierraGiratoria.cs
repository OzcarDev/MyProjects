using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CierraGiratoria : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1*speed*Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag== "Player")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }
}
