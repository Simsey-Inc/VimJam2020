﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Transform shoulderTransform;

    [SerializeField]
    private float flashlightRotationSensitivity;
    #endregion
    
    private void Update()
    {
        transform.RotateAround(shoulderTransform.position, Vector3.forward, flashlightRotationSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime);
    }

    
}