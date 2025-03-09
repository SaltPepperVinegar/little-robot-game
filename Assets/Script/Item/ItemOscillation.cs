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
    public float rotationSpeed = 20f;

    public float rotationRange = 20f;

    public bool isShaking = false;
    void Start()
    {   
        // Store the initial position of the object
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
    }
    void FixedUpdate()
    {   

        if (item.GetComponent<Item>().attached && ! isShaking){
                // Calculate the new Y position based on sine wave
                float newY = Mathf.Sin(Time.time * frequency) * amplitude*Time.deltaTime;

                // Update the object's position
                transform.localPosition += new Vector3(0, newY, 0);

            } else{
                transform.localPosition = startPosition;

        } 
    }

    public void shakeBell(){
        if (!isShaking){
            for (int i=0; i<3 ;i++){
                Debug.Log("start shaking");
                StartCoroutine(StartShaking());
            }

        }
    }

    IEnumerator StartShaking()
    {
        isShaking = true;
        
        float duration = 0.75f; // Adjust duration as needed
        float elapsedTime = 0f;
        item.GetComponent<Item>().PlaySound();

        while (elapsedTime < duration)
        {
            float angle = Mathf.Sin(Time.time * rotationSpeed) * 20f;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset rotation
        transform.localRotation = Quaternion.identity;

        yield return new WaitForSeconds(1f);


        isShaking = false;
    }
}
