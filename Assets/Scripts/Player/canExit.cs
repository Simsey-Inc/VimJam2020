using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canExit : MonoBehaviour
{
    bool hasSword = false;

    [SerializeField]
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.tag.Equals("SwordPickup"))
        {
            hasSword = true;
            animator.SetBool("hasSword", true);
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("Exit") && hasSword == true)
        {
            SceneManager.LoadScene("End");
        }
    }
}
