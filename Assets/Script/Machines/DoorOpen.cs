using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public Camera camera;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }
    public void openDoor(){
        door1.GetComponent<SlidingDoor>().SetAnimation(true);
        door2.GetComponent<SlidingDoor>().SetAnimation(true);
        camera.enabled = true;
        mainCamera.enabled = false;
    }
}