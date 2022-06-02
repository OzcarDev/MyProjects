using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BaseState currentState;
    public AttackState attackState = new AttackState();
    public MoveState moveState = new MoveState();
    public FowardState fowardState = new FowardState();
    public IdleState idleState = new IdleState();
    public LeftState leftState = new LeftState();
    public RightState rightState = new RightState();

    public int Option;
    public Rigidbody rb;
    public Animator animator;
    public float speed;
    public int life;
    private void Start()
    {
        Debug.Log("Iniciar");
        currentState = fowardState;
        currentState.EnterState(this,rb,SetTime());
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this,rb,SetTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    int SetTime()
    {
       int time = Random.Range(1, 4);
        return time;
    }
}
