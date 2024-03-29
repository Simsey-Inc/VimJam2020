﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private GameObject healthbar;

    [SerializeField]
    private string otherCollider;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private List<AudioSource> playerSounds;
    #endregion

    #region Private Variables
    private Rigidbody2D rb2d;
    #endregion

    #region Public Variables
    public bool hitAnimation = false;
    #endregion
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Hit", hitAnimation);
        hitAnimation = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(otherCollider))
        { 
            takeDamage(other.transform.position.x > gameObject.transform.position.x);
        }
    }

    private IEnumerator Knockback(float duration, float power, Vector3 direction, bool enemyInFront) 
    {
        playerMovement.IsLocked = true;

        if (enemyInFront) {
            rb2d.AddForce(new Vector2(-direction.x * power, 200));
        }
        else
        {
            rb2d.AddForce(new Vector2(direction.x * power, 200));
        }

        yield return new WaitForSeconds(duration);

        playerMovement.IsLocked = false;
    }

    private void takeDamage(bool enemyInFront)
    {
        playerSounds[0].Play();
        hitAnimation = true;
        healthbar.GetComponent<Healthbar>().decreaseNumHearts(0.5f);
        StartCoroutine(Knockback(0.15f, 125, transform.position, enemyInFront));
    }
}
