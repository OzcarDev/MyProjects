using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string scene;
 public void RestartScene()
    {
        SceneManager.LoadScene(scene);
    }
}