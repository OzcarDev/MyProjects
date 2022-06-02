using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftState : BaseState
{
    float counter;
    public override void EnterState(Enemy context, int time, GameManager gameManager)
    {
        counter = time;

        context.animator.Play("Walkizq");
       
    }

    public override void UpdateState(Enemy enemy)
    {
        counter -= Time.deltaTime;
        enemy.gameObject.transform.Translate(new Vector3(-1 * enemy.speed * Time.deltaTime, 0, 0));
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
