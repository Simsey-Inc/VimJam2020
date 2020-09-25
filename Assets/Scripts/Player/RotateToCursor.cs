using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Transform shoulderTransform;

    [SerializeField]
    private float flashlightRotationSensitivity;

    [SerializeField]
    private float maxRotationUp;

    [SerializeField]
    private float maxRotationDown;

    [SerializeField]
    private PlayerMovement playerMovement;
    #endregion

    #region Private Variables
    private Vector2 startingDifferenceVector;
    
    private float currRotation;
    #endregion

    private void Start()
    {
        currRotation = 0;
    }
    
    private void Update()
    {
        float amountToRotate = Mathf.Clamp(flashlightRotationSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime, maxRotationDown / 4, maxRotationUp / 4);
        if (currRotation + amountToRotate >= maxRotationUp)
        {
            amountToRotate = maxRotationUp - currRotation;
        }
        else if (currRotation + amountToRotate <= maxRotationDown)
        {
            amountToRotate = maxRotationDown - currRotation;
        }
        currRotation += amountToRotate;
        if (playerMovement.FacingRight)
        {
            transform.RotateAround(shoulderTransform.position, Vector3.forward, amountToRotate);
        }
        else
        {
             transform.RotateAround(shoulderTransform.position, Vector3.forward, -amountToRotate);
        }
        
    }

    
}
