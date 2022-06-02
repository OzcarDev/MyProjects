using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BaseState currentState;
    public AttackState attackState = new AttackState();
    public MoveState moveState = new MoveState();
    public RightState rightState = new RightState();
    public LeftState leftState = new LeftState();
    public DamageState damageState = new DamageState();
    public DeadState deadState = new DeadState();

    public int Option;
    public Animator animator;
    public float speed;
    public int life;
    public int damage;
    public bool canAttack;
    GameManager gameManager;
    public AudioSource shotSound;
    public AudioSource deadSound;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentState = moveState;
        currentState.EnterState(this, SetTime(),gameManager);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this, SetTime(),gameManager);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter2D(this, other);
        if (other.gameObject.tag == "SpawnZone")
        {
            canAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "SpawnZone")
        {
            canAttack = true;
        }
    }

    int SetTime()
    {
        int time = Random.Range(1, 4);
        return time;
    }
    public IEnumerator DeadSecuency()
    {
        deadSound.Play();
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

}
