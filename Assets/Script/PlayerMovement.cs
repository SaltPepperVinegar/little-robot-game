using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 10f;
    private float turnSmoothVelocity;
    public float smoothTurn = 0.1f;
    public float gravity = 20f; // the force of gravity after a player jumps
    private float vspeed = 0; // vertical speed
    public float jumpHeight = 100f;
    Vector3 moveDir;
    private bool isMoving=false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurn);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            isMoving = true;
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        } else{
            moveDir = Vector3.zero;
            isMoving = false;
        }
        Debug.Log(controller.isGrounded);

        if (controller.isGrounded)
        {
                vspeed = -2f; // small downward force to keep the player grounded

            if (Input.GetButtonDown("Jump"))
            {   
                vspeed = Mathf.Sqrt(jumpHeight * gravity);
            } else{

            }
        }
        else
        {
            vspeed -= gravity * Time.deltaTime;
        }

        Vector3 verticalMovement = new Vector3(0, vspeed, 0);
        
        controller.Move(speed * Time.deltaTime * moveDir.normalized);

        controller.Move(verticalMovement * Time.deltaTime);


    }

    public bool IsGrounded()
    {
        return controller.isGrounded;
    }
    public bool IsMoving(){
        return isMoving;
    }
    
}
