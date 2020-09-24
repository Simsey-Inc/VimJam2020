using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private float frequency;

    [SerializeField]
    private float amplitude;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(0, amplitude * Mathf.Sin(Time.timeSinceLevelLoad * frequency));
    }
}
