using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string scene;
    public float time;
    float drawTime;
    public Animator GameAnimations;
    public Text text;
 public void RestartScene()
    {
        SceneManager.LoadScene(scene);
    }
    private void Start()
    {
        GameAnimations.Play("StartAnimation");
     
    }

    private void Update()
    {
        text.text = drawTime.ToString();
        time -= Time.deltaTime;
        text.text = time.ToString();
    }
  
   

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(4f);
        RestartScene();
    }
}
