using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState(Enemy enemy, Rigidbody enemyRb, int time) {
        Debug.Log("AttackState");
        enemy.animator.Play("Attack");
    }

    public override void UpdateState(Enemy enemy) { }
    public override void OnTriggerEnter(Enemy enemy, Collider other) {
    
    
    }
}
