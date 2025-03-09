using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimation(bool DoorOpen)
    {
        animator.SetBool("DoorOpen", DoorOpen);
        
        
    }
}

