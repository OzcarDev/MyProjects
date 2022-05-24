using UnityEngine;

public class IdleState : BaseState
{
  
   

    public override void EnterState(StateManager stateManager, PlayerController playerController)
    {
      
    }
    public override void UpdateState(StateManager stateManager)
    {
       
    }
    public override void OnTriggerEnter(StateManager stateManager, Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            stateManager.SwitchState(stateManager.deadState);
        }
    }


   

    
}

