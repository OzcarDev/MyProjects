using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerController playerController;
    bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CorroborateInfo();
        animator.SetBool("horizontalVelocity",isRunning);
        animator.SetFloat("verticalVelocity", rb.velocity.y);
        animator.SetBool("Grounded", playerController.grounded);
        animator.SetBool("isDashing", playerController.isDashing);
    }

    void CorroborateInfo()
    {
        if(rb.velocity.x!= 0)
        {
            isRunning = true;
        } else
        {
            isRunning = false;
        }
    }
}
