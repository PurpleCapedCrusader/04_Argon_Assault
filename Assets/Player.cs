using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 40f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 30f;
    [Tooltip("Meters/Second")] [SerializeField] float xRange = 13f;
    [Tooltip("Meters/Second")] [SerializeField] float yRange = 8.5f;
    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 1f;
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
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

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
