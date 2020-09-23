using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private bool movingRight;

    [SerializeField]
    private bool hitWall;

    [SerializeField]
    private LayerMask wallDefine;

    // Update is called once per frame
    void Update()
    {

        hitWall = Physics2D.OverlapCircle(wallCheck.position, 0.5f, wallDefine);

        if (hitWall)
        {
            Flip();
        }
        if (movingRight)
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
    }


    private void Flip()
    {
        movingRight = !movingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
