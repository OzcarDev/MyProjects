using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<GameObject> player = new List<GameObject>();
    public List<GameObject> bodies = new List<GameObject>();
    public Transform spawn;
    public GameObject playerPrefab;
    public int maxBodies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (player.Count == 0)
        {
            Instantiate(playerPrefab, spawn.position, Quaternion.identity);
        }

        if (bodies.Count > maxBodies)
        {

            var actualGameObject = bodies[0];
            bodies.Remove(actualGameObject);
            Destroy(actualGameObject);
        }
    }
}
