
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState :  BaseState
{
    Coroutine actualCoroutine;
    Coroutine newCoroutine;
    float time;
    Rigidbody rb;
    Enemy context;
    public override void EnterState(Enemy enemy,Rigidbody enemyRB) {
        Debug.Log("Empieza");
        context = enemy;
        time = SetTime(time);
        rb = enemyRB;
        actualCoroutine = enemy.StartCoroutine(Idle());
    }
    public override void UpdateState(Enemy enemy) {
      
    }

    public override void OnTriggerEnter(Enemy enemy) {
      context.StopCoroutine(actualCoroutine);
    
    }

    Coroutine RandomMovement(Enemy context)
    {
        switch (Random.Range(0, 5))
        {
            case 0:
                return context.StartCoroutine(Idle());
            case 1:
                return context.StartCoroutine(LeftMovement());
            case 2:
                return context.StartCoroutine(RightMovement());
            case 3:
                return context.StartCoroutine(FowardMovement()); 
            default:
                return context.StartCoroutine(Idle());
               
        }
    }

    float SetTime(float time)
    {
        time = Random.Range(1, 4);
        return time;
    }
    IEnumerator Idle()
    {
        Debug.Log("Idle");

        yield return new WaitForSecondsCallBack(time, () => {
            rb.velocity = Vector3.zero;

        });
        time = SetTime(time);
        actualCoroutine=RandomMovement(context);
    }
    IEnumerator FowardMovement()
    {
        Debug.Log("FowardMovement");
        
        yield return new WaitForSecondsCallBack(time, () =>
        {
            rb.velocity = new Vector3(0, 0, -1 * context.speed);

        });
        time = SetTime(time);
        actualCoroutine = RandomMovement(context);
    }

    IEnumerator LeftMovement()
    {
        Debug.Log("LeftMovement");
       
        yield return new WaitForSecondsCallBack(time, () =>
        {
            rb.velocity = new Vector3(-1 * context.speed, 0, 0);

        });
        time = SetTime(time);
        actualCoroutine = RandomMovement(context);
    }

    IEnumerator RightMovement()
    {
        Debug.Log("RightMovement");
       
        yield return new WaitForSecondsCallBack(time, () =>
        {

            rb.velocity = new Vector3(1 * context.speed, 0, 0);
        });
        time = SetTime(time);
        actualCoroutine = RandomMovement(context);
    }
}
