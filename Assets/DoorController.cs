using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform hinge;
    public float rotationSpeed = 60f;
    private bool isOpen = false;
    

    public void OpenDoor()
    {
        if (tag == "LeftDoor")
        {
            transform.RotateAround(hinge.position, Vector3.up, 90);
        }
        else
        {
            transform.RotateAround(hinge.position, Vector3.up, -90);
        }
    }
}