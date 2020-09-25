using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canExit : MonoBehaviour
{
    bool hasSword = false;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private List<AudioSource> playerSounds;

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.tag.Equals("SwordPickup"))
        {
            playerSounds[0].Play();
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
