using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : Movement
{
	

    // Start is called before the first frame update
    void Start()
    {
        
		destiny = end;
    }

	// Update is called once per frame
	void Update()
    {
       if(isActivated) HorizontalMovement();
    }

    
}
