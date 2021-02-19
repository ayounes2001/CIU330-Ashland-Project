using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJump : MonoBehaviour
{
    public Rigidbody rb;
    public Animator playerAnimator;
   public bool isGrounded;
    public LayerMask ground;
    public float jumpForce;

    public float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
  

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") && isGrounded == true)
        {

            if (!Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                isGrounded = false;
                //changing to jump animation
                playerAnimator.SetInteger("CurrentAnimation", 2);
                Debug.DrawLine(transform.position, -Vector3.up);
            }
            else
            {
                isGrounded = true;
            }
           
        }
        //checking if player is falling and chaning animation
        if (rb.velocity.y < -1) { playerAnimator.SetInteger("CurrentAnimation", 4); }
    }

    private void OnCollisionEnter(Collision other)
    {       

       
            isGrounded = true;
      
           
   }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, distToGround);
    }

}
