using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotOscillation : MonoBehaviour
{

    public float amplitude = 1f; // Height of the wave
    public float frequency = 1f; // Speed of the wave
    private PlayerMovement playerMovement; 
    private Vector3 startPosition;
    private Quaternion startRotation;

    public float rotationSpeed = 5f;
    void Start()
    {   
        playerMovement = GetComponentInParent<PlayerMovement>();
        // Store the initial position of the object
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }

    void FixedUpdate()
    {   
        if (!playerMovement.IsMoving() )
        {   
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);


        } else{
            transform.localPosition = startPosition;
            Quaternion targetRotation = Quaternion.Euler(20f, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);

        }
        if (playerMovement.IsGrounded()){
                // Calculate the new Y position based on sine wave
                float newY = Mathf.Sin(Time.time * frequency) * amplitude*Time.deltaTime;

                // Update the object's position
                transform.localPosition += new Vector3(0, newY, 0);

            } else{
                transform.localPosition = startPosition;

        } 
    }
}

