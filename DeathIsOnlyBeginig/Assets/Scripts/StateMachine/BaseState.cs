using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager stateManager,PlayerController playerController);
    public abstract void UpdateState(StateManager stateManager);
    public abstract void OnTriggerEnter(StateManager stateManager,Collider2D other); 


}
