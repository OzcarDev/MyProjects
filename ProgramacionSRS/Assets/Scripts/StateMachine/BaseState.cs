
using UnityEngine;

public abstract class BaseState 
{

    public abstract void EnterState(PlayerController playerController);


    public abstract void UpdateState(PlayerController playerController);


    public abstract void OnCollisionEnter(PlayerController playerController, Collider2D other);
    
  
}
