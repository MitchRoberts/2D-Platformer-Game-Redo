using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sprite;
    private Animator ani;

    [SerializeField] private LayerMask JumpGround;

    private float dirX = 0f;
    private int jump = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { Idle, Running, Jump, Falling }

    [SerializeField] private AudioSource jumpSoundeffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jump < 1) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump += 1;
            jumpSoundeffect.Play();
        }
        
        AnimationState();

        if (IsGrounded())
        {
            jump = 0;
        }

    }

    private void AnimationState()
    {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state= MovementState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.Jump;
        }

        else if (rb.velocity.y < -0.1f) 
        {
            state = MovementState.Falling;
        }

        ani.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, JumpGround);
    }

}
