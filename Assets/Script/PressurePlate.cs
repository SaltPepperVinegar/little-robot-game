using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public SlidingDoor door1;
    public SlidingDoor door2;
    private bool DoorOpen = false;
   
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter running");
        if (other.tag == "Player")
        {
            if (door1 != null && door2 != null)
            {
                Debug.Log("this is running");
                DoorOpen = !DoorOpen;
                door1.SetAnimation(DoorOpen);
                door2.SetAnimation(DoorOpen);
            }
        }
    }
}
