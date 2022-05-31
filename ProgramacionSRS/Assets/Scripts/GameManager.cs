using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string scene;
    public float time;
 public void RestartScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        
    }
}
