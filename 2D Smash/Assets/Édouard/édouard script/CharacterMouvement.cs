using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    public float moveSpeed;

    public bool isJumping = false;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void FixeUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
}
