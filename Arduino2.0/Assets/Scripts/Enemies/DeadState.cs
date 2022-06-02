using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
   
    public override void EnterState(Enemy context, int time, GameManager gameManager)
    {
        gameManager.Score++;
        context.animator.Play("Dead");
       
        context.StartCoroutine(context.DeadSecuency());
    }

    public override void UpdateState(Enemy enemy)
    {

    }

    public override void OnTriggerEnter2D(Enemy enemy, Collider2D other)
    {

    }


   
}
