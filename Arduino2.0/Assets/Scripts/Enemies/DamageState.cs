using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : BaseState
{

    public override void EnterState(Enemy context, int time, GameManager gameManager)
    {
        context.life--;
        if (context.life <= 0)
        {
            context.SwitchState(context.deadState);
        }
        else
        {
            context.animator.Play("Damage");
            context.deadSound.Play();
            context.StartCoroutine(Damage(context));
        }
    }

    IEnumerator Damage(Enemy enemy)
    {
        yield return new WaitForSeconds(1);
        enemy.SwitchState(enemy.moveState);

    }

    public override void UpdateState(Enemy enemy)
    {
        
    }

    public override void OnTriggerEnter2D(Enemy enemy, Collider2D other)
    {

    }
}
