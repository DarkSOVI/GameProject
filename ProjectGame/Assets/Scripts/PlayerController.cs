using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Speed value")]
    public float runSpeed = 0.4f;

    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private float speed;
    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        speed = (runSpeed * rb.velocity.x);
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        HandleHorizontalMovement();
        if (facingRight == false && speed > 0)
        {
            Flip();
        }
        else if (facingRight == true && speed < 0)
        {
            Flip();
        }

        if (speed == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }
    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = InputManager.GetInstance().GetMoveDirection();
        rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y);
    }
    private void Flip ()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
