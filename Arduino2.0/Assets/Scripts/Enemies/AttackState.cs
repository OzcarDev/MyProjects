using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    float counter;
    public override void EnterState(Enemy context, int time, GameManager gameManager)
    {
        counter = 1;
        gameManager.Damage(context.damage);
        
        context.animator.Play("Attack");
        context.shotSound.Play();
    }

    public override void UpdateState(Enemy enemy)
    {
        counter -= Time.deltaTime;

        if (counter <= 0) enemy.SwitchState(enemy.moveState);
    }

    public override void OnTriggerEnter2D(Enemy enemy, Collider2D other)
    {
        if (other.gameObject.tag == "Mirilla")
        {
            enemy.SwitchState(enemy.damageState);
        }
    }
}
