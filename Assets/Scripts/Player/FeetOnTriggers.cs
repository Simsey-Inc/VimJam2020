using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.tag.Equals("Death_Zone"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Mathf.Abs(playerMovement.getVelocity().y) < 0.01f && other.tag.Equals("Environment"))
        {
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

    private IEnumerator SetNumJumpsToZero()
    {
        // Lets the player make jumps they slightly shouldn't
        yield return new WaitForSeconds(timeBeforeSetNumJumpsToZero);
        playerMovement.SetNumJumpsToZero();
        
    }
}
