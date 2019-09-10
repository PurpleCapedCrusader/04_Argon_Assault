using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f;
    [Tooltip("Meters/Second")] [SerializeField] float xRange = 17f;
    [Tooltip("Meters/Second")] [SerializeField] float yRange = 7f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = -1.2f;
    // [SerializeField] float controlYawFactor = 15f;
    [SerializeField] float positionRollFactor = -0f;
    [SerializeField] float controlRollFactor = -30f;
    float xThrow, yThrow, zThrow;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        processTranslation();
        processRotation();
    }
    private void processRotation()
    {
        //float yawDueToPosition = -transform.localPosition.x * positionYawFactor;
        //float yawDueToControlThrow = xThrow * controlYawFactor;

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float rollDueToPosition = transform.localPosition.x * positionRollFactor;
        float rollDueToControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = rollDueToPosition + rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void processTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
