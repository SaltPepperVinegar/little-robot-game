using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 10f;
    private float turnSmoothVelocity;
    public float smoothTurn = 0.1f;
    public float gravity = 20f; // the force of gravity after a player jumps
    private float vspeed = 0; // vertical speed
    public float jumpHeight = 10f;
    public GameObject[] MovePoint;
    public bool isMoving=false;
    public bool idling = false;

    // Update is called once per frame
    void Update()
    {   
        if (! idling){
            StartCoroutine(Idle());
        }

    }
IEnumerator Idle()
{
    if (MovePoint == null || MovePoint.Length < 3)
    {
        Debug.LogWarning("MovePoint array is null or too short!");
        yield break; // Exit coroutine if there aren't enough waypoints.
    }

    idling = true;

    for (int i = 0; i < 3; i++)
    {
        // Pause before moving (Optional: for a natural delay effect)
        yield return new WaitForSeconds(1f);
        Vector3 toDirection = MovePoint[i].transform.position - transform.position;
        toDirection.y = 0; 
        while (toDirection.sqrMagnitude >= 0.1f)
        {   
            isMoving = true;
            if (toDirection.sqrMagnitude > 0.01f) // Prevent division by zero
            {
                Vector3 direction = toDirection.normalized;
                
                // 🔥 FIX: Proper rotation smoothing 🔥
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurn);

                // Apply rotation *only* if needed
                if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.1f)
                {
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }

                // Apply gravity
                if (controller.isGrounded)
                {
                    vspeed = -2f; // Small downward force to stay grounded
                }
                else
                {
                    vspeed -= gravity * Time.deltaTime;
                }

                // Move character
                Vector3 movement = (speed * Time.deltaTime * direction) + new Vector3(0, vspeed * Time.deltaTime, 0);
                controller.Move(movement);
            }   
            toDirection = MovePoint[i].transform.position - transform.position;
            toDirection.y = 0; 
            yield return null;
        }
        isMoving = false;
        controller.Move(Vector3.zero);
        Debug.Log($"Finished cycle: {i + 1}");

        // Wait at the waypoint before moving to the next
        yield return new WaitForSeconds(2f);
    }

    idling = false;
}


    public bool IsGrounded()
    {
        return controller.isGrounded;
    }
    public bool IsMoving(){
        return isMoving;
    }
    
}
