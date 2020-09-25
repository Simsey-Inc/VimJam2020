using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PickupHandler : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Light2D flashlight;

    [SerializeField]
    private float amtIncreaseInnerAngle;

    [SerializeField]
    private float amtIncreaseOuterAngle;

    [SerializeField]
    private float amtIncreaseInnerRadius;

    [SerializeField]
    private float amtIncreaseOuterRadius;

    [SerializeField]
    private float amtIncreaseIntensity;

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("BatteryPickup")) {
            flashlight.pointLightInnerAngle += amtIncreaseInnerAngle;
            flashlight.pointLightOuterAngle += amtIncreaseInnerAngle;
            flashlight.pointLightInnerRadius += amtIncreaseInnerRadius;
            flashlight.pointLightOuterRadius += amtIncreaseOuterRadius;
            flashlight.intensity += amtIncreaseIntensity;
            Destroy(other.gameObject);
        }

    }
}
