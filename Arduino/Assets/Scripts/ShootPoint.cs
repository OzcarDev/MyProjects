using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    public Camera camera;
    public Transform mira;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.TransformPoint(mira.position);
    }
}
