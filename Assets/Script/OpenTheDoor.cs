using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public void Start()
    {
        
    }
    public void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        door1.GetComponent<DoorController>().OpenTheDoor(-1);
        door2.GetComponent<DoorController>().OpenTheDoor(1);

    }
}

