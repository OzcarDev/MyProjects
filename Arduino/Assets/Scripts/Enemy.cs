using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Idle()
    {

    }

    IEnumerator FowardMovement()
    {
       
    }

    IEnu LeftMovement()
    {
        
    }

    void RightMovement()
    {

    }
}
