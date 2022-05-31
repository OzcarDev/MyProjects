using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform item;
    public Transform destiny;
    public float speed;
    public bool isActivated;
    public void HorizontalMovement()
    {
        if (item != null)
        {
            item.position = Vector3.MoveTowards(item.position, destiny.position, speed * Time.deltaTime);

            if (item.position == end.position)
            {
                destiny = start;
            }

            if (item.position == start.position)
            {
                destiny = end;
            }
        }
    }
}
