using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetOnTriggers : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Environment")) {
            playerMovement.IsGrounded = true;
            playerMovement.ResetJumps();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Environment")) {
           playerMovement.IsGrounded = false;
           // This prevents the player from jumping if they fall, should we allow them to?
           playerMovement.SetNumJumpsToZero();
        }
    }
}
