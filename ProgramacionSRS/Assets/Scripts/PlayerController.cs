using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public BaseState currentState;
   public PowerState powerState = new PowerState();
   public DamageState damageState = new DamageState();
   public IdleState idleState= new IdleState();
    public AudioSource deadSound;
    public Animator deadAnimation;
    public GameManager gameManager;
    [Header("Movement")]
    public float speed;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontal = Input.GetAxis("Horizontal");
        Movement();
        currentState.UpdateState(this);
    }

    void Movement()
    {
        transform.Translate(new Vector3(speed*Time.deltaTime*horizontal,0,0));
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        currentState.OnTriggerEnter(this, other);
    }

	private void OnCollisionEnter2D(Collision2D col)
	{
		currentState.OnCollisionEnter(this, col);
	}

	private void OnCollisionExit2D(Collision2D col)
	{
		currentState.OnCollisionExit(this, col);
	}

    public void DestroyOther(GameObject other)
    {
        Destroy(other);
    }
}

	


