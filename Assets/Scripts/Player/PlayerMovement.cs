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
    #endregion

    #region Components
    private Rigidbody2D rb;
    #endregion

    #region Private Variables
    private float movementX;
    
    private float numJumps;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numJumps = maxNumJumps;
    }

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        if (IsGrounded()) {
            ResetJumps();
        }
        if (Input.GetButtonDown("Jump") && numJumps > 0) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move() {
        if (movementX * rb.velocity.x <= 0) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        rb.AddForce(new Vector2(moveForce * movementX, 0));

        if (rb.velocity.x > maxMoveSpeed) {
            rb.velocity = new Vector2(maxMoveSpeed, rb.velocity.y);
        } else if (rb.velocity.x < -maxMoveSpeed) {
            rb.velocity = new Vector2(-maxMoveSpeed, rb.velocity.y);
        }
    }

    private void Jump() {
        numJumps--;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce));
    }

    private bool IsGrounded() {
        Collider2D[] collidingWithFeet = Physics2D.OverlapCircleAll(feet.position, 0.01f); 

        foreach (Collider2D collider in collidingWithFeet) {
            if (collider.tag.Equals("Environment")) {
                return true;
            }
        }
        return false;
    }

    private void ResetJumps() {
        numJumps = maxNumJumps;
    }

}
