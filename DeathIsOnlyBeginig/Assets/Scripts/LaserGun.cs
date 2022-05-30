using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
  
    private Transform target;
    public Transform gun;
    Vector2 direction;
    public GameObject bullet;
    public Transform shootPoint;
    public float force;

    // Update is called once per frame

    private void Start()
    {
        InvokeRepeating("Shoot", 1, 3);
    }
    void Update()
    {
        if (target == null) return;
            Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;

        gun.right = direction;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    void Shoot() {
        if (target != null)
        {
            var actualObject = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            actualObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }
}
