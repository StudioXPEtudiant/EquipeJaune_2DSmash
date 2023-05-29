using UnityEngine;

   public class PlayerMovement : MonoBehaviour
{   
   public float moveSpeed;
   public float jumpForce;

 private bool isJumping = false;
 private bool isGrounded;

 public Transform groundCheckLeft;
 public Transform groundCheckRight;

   public Rigidbody2D rb;
   private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

       if(Input.GetButtonDown("Jump") && isGrounded)
       {
           isJumping = true;
       }

        MovePlayer(horizontalMouvement);
    }

    void MovePlayer(float _horizontalMouvement)
    {
     Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
     rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

     if(isJumping == true)
     {
        rb.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
     }
    }
}
