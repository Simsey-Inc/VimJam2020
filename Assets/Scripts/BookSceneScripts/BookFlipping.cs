using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFlipping : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    private int pageNum = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pageNum++;
            animator.SetInteger("NextPage", pageNum);
        }
    }
}
