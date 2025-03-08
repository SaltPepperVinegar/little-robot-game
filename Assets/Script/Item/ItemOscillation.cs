using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOscillation : MonoBehaviour
{    
    public float amplitude = 0.8f; // Height of the wave
    public float frequency = 8f; // Speed of the wave
    public GameObject item;
    private Vector3 startPosition;
    private Quaternion startRotation;
    public float rotationSpeed = 5f;
    void Start()
    {   
        // Store the initial position of the object
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }
    void FixedUpdate()
    {   

        if (item.GetComponent<Item>().attached){
                // Calculate the new Y position based on sine wave
                float newY = Mathf.Sin(Time.time * frequency) * amplitude*Time.deltaTime;

                // Update the object's position
                transform.localPosition += new Vector3(0, newY, 0);

            } else{
                transform.localPosition = startPosition;

        } 
    }
}
