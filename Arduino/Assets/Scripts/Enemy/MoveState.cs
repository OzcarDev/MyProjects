
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState :  BaseState
{
  

 
    Enemy context;
    public override void EnterState(Enemy enemy,Rigidbody enemyRB,int time) {
        context = enemy;
         RandomMovement(); 
    }

    public override void UpdateState(Enemy enemy) { }


    void RandomMovement()
    {
        int newOption;
        do
        {
            newOption = Random.Range(0, 4);
        } while (newOption == context.Option);
       context.Option = newOption;
        switch (context.Option)
        {
            case 0:
                context.SwitchState(context.idleState);
                break;
            case 1:
                context.SwitchState(context.fowardState);
                break;
            case 2:
                context.SwitchState(context.leftState);
                break;
            case 3:
                context.SwitchState(context.rightState);
                break;
            
                
               
        }
    }



    public override void OnTriggerEnter(Enemy enemy, Collider other)
    {

        if (other.gameObject.tag == "AttackZone")
        {

            enemy.SwitchState(enemy.attackState);
        }

    }


    


}
