using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardState : BaseState
{
    float counter;
    public override void EnterState(Enemy enemy, Rigidbody rb, int time)
    {
        counter = time;
        
        enemy.animator.Play("Walk");
        enemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
        
           

       
      
      
    }

    public override void UpdateState(Enemy enemy) {
        counter -= Time.deltaTime;
        enemy.gameObject.transform.Translate(new Vector3(0, 0, -1*enemy.speed*Time.deltaTime));
        if (counter <= 0) enemy.SwitchState(enemy.moveState);
    }
    public override void OnTriggerEnter(Enemy enemy, Collider other)
    {

        if(other.gameObject.tag == "AttackZone")
        {
            enemy.SwitchState(enemy.attackState);
        }
    }
}
