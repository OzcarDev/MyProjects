using UnityEngine;

public class DeadState : BaseState
{

    Rigidbody2D rb;
    GameManager gameManager;
    public override void EnterState(StateManager stateManager, PlayerController playerController)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.player.Remove(stateManager.gameObject);
        gameManager.bodies.Add(stateManager.gameObject);
        rb=playerController.gameObject.GetComponent<Rigidbody2D>();
        playerController.enabled = false;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        
    }
    public override void UpdateState(StateManager stateManager)
    {

    }
    public override void OnTriggerEnter(StateManager stateManager, Collider2D other)
    {
       
    }
}

