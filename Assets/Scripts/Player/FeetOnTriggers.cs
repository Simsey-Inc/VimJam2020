using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetOnTriggers : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float timeBeforeSetNumJumpsToZero;
    #endregion

    #region Private Variables
    private PlayerMovement playerMovement;
    #endregion

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
           StartCoroutine(SetNumJumpsToZero());
        }

        
    }

    // This prevents the player from jumping if they fall, should we allow them to?
    private IEnumerator SetNumJumpsToZero()
    {
        // Lets the player make jumps they slightly shouldn't
        yield return new WaitForSeconds(timeBeforeSetNumJumpsToZero);
        playerMovement.SetNumJumpsToZero();
        
    }
}
