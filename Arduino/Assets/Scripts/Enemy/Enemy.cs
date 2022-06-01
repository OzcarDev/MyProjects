using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BaseState currentState;
    public AttackState attackState = new AttackState();
    public MoveState moveState = new MoveState();
    public Rigidbody rb;

    public float speed;

    private void Start()
    {
        Debug.Log("Iniciar");
        currentState = moveState;
        currentState.EnterState(this,rb);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this,rb);
    }
}
