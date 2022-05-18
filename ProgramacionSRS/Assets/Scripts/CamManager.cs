using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private Transform pTransform;

    [SerializeField]public float offset;

    void Start()
    {
        pTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = pTransform.position.x;
        temp.x += offset;

        temp.y = pTransform.position.y;
        temp.y += offset;
        transform.position = temp;
    }

}
