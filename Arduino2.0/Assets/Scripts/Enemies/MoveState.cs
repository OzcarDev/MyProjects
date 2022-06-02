using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    Enemy context;
    public override void EnterState(Enemy enemy, int time, GameManager gameManager)
    {
        context = enemy;
        RandomMovement();
    }

    public override void UpdateState(Enemy enemy)
    {

    }

    public override void OnTriggerEnter2D(Enemy enemy, Collider2D other)
    {
        if (other.gameObject.tag == "Mirilla")
        {
            enemy.SwitchState(enemy.damageState);
        }
    }

    void RandomMovement()
    {
        int newOption;
        do
        {
            newOption = Random.Range(0, 3);
        } while (newOption == context.Option);
        context.Option = newOption;
        switch (context.Option)
        {
           
            case 0:
                if (!context.canAttack) RandomMovement();
                else context.SwitchState(context.attackState);
                break;
            case 1:
                context.SwitchState(context.leftState);
                break;
            case 2:
                context.SwitchState(context.rightState);
                break;



        }
    }
}
