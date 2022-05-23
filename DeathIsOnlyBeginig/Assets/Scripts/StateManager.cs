using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public DeadState deadState = new DeadState();
    public DashState dashState = new DashState();
    public IdleState idleState = new IdleState();
    public JumpState jumpState = new JumpState();

    [Header("For Movement")]
    public float speed;
    float horizontalAxis;
    Rigidbody2D rb;

     void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        currentState = idleState;
        currentState.EnterState(this);
    }

     void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        currentState.UpdateState(this);
        HorizontalMovement();
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }


    void HorizontalMovement()
    {
        Debug.Log(horizontalAxis);
        rb.velocity = new Vector2(speed * horizontalAxis * Time.deltaTime,0);
    }

}
