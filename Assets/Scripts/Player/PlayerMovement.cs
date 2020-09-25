using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float moveForce;

    [SerializeField]
    private float maxMoveSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private int maxNumJumps;

    [SerializeField]
    private Transform feet;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private List<AudioSource> playerSounds;
    #endregion

    #region Components
    private Rigidbody2D rb;
    #endregion

    #region Private Variables
    private float movementX;
    
    private float numJumps;

    private bool facingRight = true;

    private bool isGrounded = false;

    private bool isLocked = false;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool IsLocked { get => isLocked; set => isLocked = value; }
    public bool FacingRight { get => facingRight; set => facingRight = value; }
    #endregion

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numJumps = maxNumJumps;
    }

    private void Update()
    {
        if (IsLocked)
        {
            return;
        }
        movementX = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movementX));
        animator.SetBool("isGrounded", IsGrounded);

        if (Input.GetButtonDown("Jump") && numJumps > 0) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (IsLocked) 
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        if (movementX * rb.velocity.x <= 0) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        rb.AddForce(new Vector2(moveForce * movementX, 0));

        if (rb.velocity.x > maxMoveSpeed) {
            rb.velocity = new Vector2(maxMoveSpeed, rb.velocity.y);
        } else if (rb.velocity.x < -maxMoveSpeed) {
            rb.velocity = new Vector2(-maxMoveSpeed, rb.velocity.y);
        }

        if (Mathf.Abs(moveForce * movementX) > 0 && !playerSounds[1].isPlaying && isGrounded)
        {
            if (Random.Range(0,8) < 1) {
                playerSounds[1].volume = Random.Range(0.01f, 0.02f);
                playerSounds[1].pitch = Random.Range(0.7f, 1.1f);
                playerSounds[1].Play();
            }
            
        }

        if (movementX > 0 && !FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movementX < 0 && FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Jump()
    {
        playerSounds[0].Stop();
        playerSounds[0].Play();
        numJumps--;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public void ResetJumps()
    {
        numJumps = maxNumJumps;
    }

    public void SetNumJumpsToZero()
    {
        numJumps = 0;
    }

    public Vector2 getVelocity()
    {
        return rb.velocity;
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
