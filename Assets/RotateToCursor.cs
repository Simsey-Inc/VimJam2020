using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private Transform shoulderTransform;

    [SerializeField]
    private Transform flashlightTransform;
    #endregion

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 flashlightToMouse = Input.mousePosition - flashlightTransform.position;
        Vector2 shoulderToMouse = Input.mousePosition - shoulderTransform.position;
        Vector2 shoulderToFlashlight = flashlightTransform.position - Input.mousePosition;
    }

    
}
