using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Transform shoulderTransform;

    [SerializeField]
    private Transform flashlightStartingTransform;

    [SerializeField]
    private float flashlightRotationSensitivity;

    [SerializeField]
    private float maxRotationUp;

    [SerializeField]
    private float maxRotationDown;
    #endregion

    #region Private Variables
    private Vector2 startingDifferenceVector;
    #endregion
    
    private void Update()
    {
        transform.RotateAround(shoulderTransform.position, Vector3.forward, flashlightRotationSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime);
    }

    
}
