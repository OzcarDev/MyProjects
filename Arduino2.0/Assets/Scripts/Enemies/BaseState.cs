using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(Enemy context, int time,GameManager gameManager);

    public abstract void UpdateState(Enemy enemy);

    public abstract void OnTriggerEnter2D(Enemy enemy, Collider2D other);
}
