
using UnityEngine;

public abstract class BaseState 
{

    public abstract void EnterState(PlayerController playerController);


    public abstract void UpdateState(PlayerController playerController);


    public abstract void OnTriggerEnter(PlayerController playerController, Collider2D other);

	public abstract void OnCollisionEnter(PlayerController playerController, Collision2D col);

	public abstract void OnCollisionExit(PlayerController playerController, Collision2D col);
    
  
}
