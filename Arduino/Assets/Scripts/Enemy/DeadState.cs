using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    public override void EnterState(Enemy enemy, Rigidbody enemyRb, int time) { }

    public override void UpdateState(Enemy enemy) { }
    public override void OnTriggerEnter(Enemy enemy, Collider other) { }
}
