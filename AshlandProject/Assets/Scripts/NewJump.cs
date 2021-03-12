using UnityEngine;

public class NewJump : MonoBehaviour
{
    public PlayerAnimations pLayerAnimate;
    public Rigidbody rb;
   
   public bool isGrounded;
    public float jumpForce;

    public float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
  

    // Update is called once per frame
    void Update()
    {
        Jump();
        if (rb.velocity == Vector3.zero) { pLayerAnimate.CurrentAnimation = AnimationStates.idle; }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            pLayerAnimate.CurrentAnimation = AnimationStates.jumping;
            if (!Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
            {
               
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                isGrounded = false;
                //changing to jump animation
                
                Debug.DrawLine(transform.position, -Vector3.up);
            }
            else
            {
                isGrounded = true;
            }
           
        }
        //checking if player is falling and chaning animation
        if (rb.velocity.y < 0 && isGrounded == false || rb.velocity.y > 0 && isGrounded == false) { pLayerAnimate.CurrentAnimation = AnimationStates.inair; }       
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
