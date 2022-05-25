using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
	public Transform start;
	public Transform end;
	public Transform platform;
	Transform destiny;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {

		destiny = end;
    }

	// Update is called once per frame
	void Update()
	{
		platform.position = Vector3.MoveTowards(platform.position, destiny.position, speed * Time.deltaTime);

		if (platform.position == end.position)
		{
			destiny = start;
		}

		if (platform.position == start.position)
		{
			destiny = end;
		}
	}
}
