using UnityEngine;

public class DeadState : BaseState
{

    Rigidbody2D rb;
    public override void EnterState(StateManager stateManager, PlayerController playerController)
    {
        rb=playerController.gameObject.GetComponent<Rigidbody2D>();
        playerController.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
       
        
    }
    public override void UpdateState(StateManager stateManager)
    {

    }
    public override void OnTriggerEnter(StateManager stateManager, Collider2D other)
    {

    }
}

