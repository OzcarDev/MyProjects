using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("For Movement")]
    public float speed;
    Rigidbody2D rb;
    float horizontalAxis;

    [Header("For Jump")]
    public float jumpForce;
    [SerializeField] LayerMask groundLayer;
    public bool grounded;
    public Transform groundCheckPoint;
    [SerializeField] Vector2 groundCheckSize;
    public float coyoteTime;
    private float coyoteTimeCounter;
    public float jumpBuffer;
    private float jumpBufferCounter;
    
    [Header("For Dash")]
    public float dashForce;
    public float dashTime;
    private bool canDash;
    public bool isDashing;
    public Collider2D dashingBox;
    public Collider2D walkingBox;


    GameManager gameManager;
    public CamTarget camTarget;

    void Start()
    {
        camTarget = GameObject.Find("Main Camera").GetComponent<CamTarget>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.player.Add(this.gameObject);
        isDashing = false;
        camTarget.target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        CheckGround();
        CoyoteTime();
        Jump();
        ChangeBoxCollider();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    void ChangeBoxCollider()
    {
        if (isDashing && !grounded)
        {
            dashingBox.enabled = true;
            walkingBox.enabled = false;
        }
        else if( grounded && !isDashing){
            dashingBox.enabled = false;
            walkingBox.enabled = true;
        }
    }
    void HorizontalMovement()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(speed * horizontalAxis, rb.velocity.y);
            if (horizontalAxis < 0.0f) rb.gameObject.transform.localScale = new Vector3(-1f,1f,1f);
            else if (horizontalAxis > 0.0f) rb.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) jumpBufferCounter = jumpBuffer;
        else jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;
        } 
        if (Input.GetKeyDown(KeyCode.E)&&!grounded&&canDash)
        {
            Debug.Log("Dash");
            Dash(gameObject.transform.localScale.x*2);
            canDash = false;
        }
    }

    void CoyoteTime()
    {
        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
            canDash = true;

            isDashing = false;
        }

        else if (!grounded) coyoteTimeCounter -= Time.deltaTime;
        

        
    }

    void Dash(float direction)
    {
        isDashing = true;
        Debug.Log(direction);
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(dashForce * direction, 0f), ForceMode2D.Impulse);

    }
    void CheckGround()
    {
        grounded = Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize,0, groundLayer);
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.parent = other.gameObject.GetComponentInParent<Transform>();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent = null;
        }
    }

    */
     private void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawCube(groundCheckPoint.position, groundCheckSize);
     }
}
