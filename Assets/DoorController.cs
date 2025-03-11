using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform hinge;
    public float rotationSpeed = 60f;
<<<<<<< HEAD
    public bool isOpen = false;
        
    private float timer;
    public void Start()
    {
    }
    public void Update()
    {

    }
    public void OpenTheDoor(int factor){
        if(!isOpen){
            isOpen = true;
            StartCoroutine(openDoor(factor));
            Debug.Log("open");
        }

    }
    IEnumerator openDoor(int factor){
        timer = 0 ;
        while(timer<2){
            Debug.Log("opening");

            transform.RotateAround(hinge.position, Vector3.up, -factor*rotationSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
            
=======
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
>>>>>>> main
        }
    }
}