using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int maxHP;

    [SerializeField]
    private string otherCollider;

    [SerializeField]
    private Animator animator;
    #endregion

    #region Private Variables
    private int currentHP;

    private Rigidbody2D rb2d;
    #endregion

    #region Public Variables
    public bool hitAnimation = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Hit", hitAnimation);

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        hitAnimation = false;

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(otherCollider))
        { 
            takeDamage();
        }
    }

    private IEnumerator Knockback(float duration, float power, Vector3 direction) 
    {
        float timer = 0;

        while (duration > timer)
        {
            timer += Time.deltaTime;
            
            rb2d.AddForce(new Vector2(-direction.x * power, 200));
        }

        yield return 0;
    }

    private void takeDamage()
    {
        currentHP--;
        hitAnimation = true;
        StartCoroutine(Knockback(0.02f, 300, transform.position));
    }
}
