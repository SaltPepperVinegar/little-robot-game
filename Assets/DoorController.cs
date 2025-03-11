using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform hinge;
    public float rotationSpeed = 60f;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            isOpen = !isOpen;
        }

        if (isOpen)
        {
            transform.RotateAround(hinge.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(hinge.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }
}