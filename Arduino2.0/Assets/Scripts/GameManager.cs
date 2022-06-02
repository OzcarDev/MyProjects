using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLife;
    public Animator animator;
    public int Score;
    public Text scoreText;
    public Text lifeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score;
        lifeText.text = "Life: " + playerLife;
        if (playerLife <=0) SceneManager.LoadScene("RestartScene");
    }

    public void Damage(int damage)
    {
      playerLife -= damage;
        animator.Play("DamagePanel");
    }
}
