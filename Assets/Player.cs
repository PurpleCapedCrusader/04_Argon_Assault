using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 4f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        print("xOffestThisFrame = " + xOffsetThisFrame);

        float yOffsetThisFrame = yThrow * ySpeed * Time.deltaTime;
        print("yOffestThisFrame = " + yOffsetThisFrame);
    }
}
