using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 8f;
    public float walk = 8f;
    public float sprint = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isAiming;

    private float fovDefault;
    public float fovAim = 45f;
    private float fovSprint;

    void Start()
    {
        //Start the Camera field of view at 60
        fovDefault = Camera.main.fieldOfView;
        fovSprint = fovDefault * 1.15f;
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        // aiming FOV
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            FovSmoothSwitcher(fovAim, 0.6f);
        } else
        {
            isAiming = false;
        }

        Debug.Log(isAiming);

        // allow the player to sprint with shift  !! change to use built in sprint button !!
        if (Input.GetKey(KeyCode.LeftShift) && !isAiming)
        {
            speed = sprint;
            FovSmoothSwitcher(fovSprint, 0.095f);
        } else
        {
            speed = walk;
        }


        // Set FOV back to default when no special events happening
        if (!isAiming && speed != sprint)
        {
            FovSmoothSwitcher(fovDefault, 0.1f);
        }

        // moving the player
        controller.Move(move * speed * Time.deltaTime); 

        // allow the player to jump only if grounded
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log(Camera.main.fieldOfView);

        

    }

    // Smooth FOV change (target_fov, intergral amount)
    void FovSmoothSwitcher(float fov, float fovSmooth)
    {
        if (Camera.main.fieldOfView >= (fov - fovSmooth) && Camera.main.fieldOfView <= (fov + fovSmooth))
        {
            Camera.main.fieldOfView = fov;
            return;
        }

        if (Camera.main.fieldOfView >= fov)
        {
            Camera.main.fieldOfView = Camera.main.fieldOfView - fovSmooth;
        } else if (Camera.main.fieldOfView <= fov)
        {
            Camera.main.fieldOfView = Camera.main.fieldOfView + fovSmooth;
        }

        return;
    }
}
