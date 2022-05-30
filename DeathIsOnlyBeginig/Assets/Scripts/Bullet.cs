using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float counter = 7;

    void Start()
    {
        
    }

    
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "IgnoreBullet")
        {
            Debug.Log("COlision");
            Destroy(this.gameObject);
        }
    }
}
