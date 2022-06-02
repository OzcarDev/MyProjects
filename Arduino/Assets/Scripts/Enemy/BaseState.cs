using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(Enemy enemy,Rigidbody enemyRb, int time);

    public abstract void UpdateState(Enemy enemy);
    public abstract void OnTriggerEnter(Enemy enemy,Collider other);


}
