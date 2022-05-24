using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public DeadState deadState = new DeadState();
    public IdleState idleState = new IdleState();
    PlayerController playerController;
    
  

     void Start()
    {
       
        playerController = this.gameObject.GetComponent<PlayerController>();
        currentState = idleState;
        currentState.EnterState(this,playerController);
    }

     void Update()
    {
     
        currentState.UpdateState(this);
        
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this,playerController);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(this, other);
    }




}
