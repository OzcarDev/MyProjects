
using UnityEngine;

public class IdleState : BaseState
{
    GameManager gameManager;
    public override void EnterState(PlayerController playerController) {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public override void UpdateState(PlayerController playerController) { }


    public override void OnCollisionEnter(PlayerController playerController, Collider2D other) {

        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Damage");
            gameManager.RestartScene();
        }

    }
}
