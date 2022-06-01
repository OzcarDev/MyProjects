using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string scene;
    public int time;
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
        StartCoroutine(Timer());
    }

    private void Update()
    {
        text.text = drawTime.ToString();   
    }
    IEnumerator Timer()
    {
        for (int i = time; i >= 0; i--)
        {
            drawTime = i;
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(Timeout());
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(4f);
        RestartScene();
    }
}
