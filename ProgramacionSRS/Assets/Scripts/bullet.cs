using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : BasicMovement
{
   
    void Start()
    {
        Invoke("Destroy", 7);
    }

    
    void Destroy()
    {
        Destroy(this.gameObject);
    }


}
