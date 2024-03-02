using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {
    // { get; private set; } - allows scripts to acess the data but not change it. Shorthand for classic getter and setter methods
    public bool CanMove { get; private set; } = true; 
    private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
    private bool ShouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded;
    private bool ShouldCrouch => Input.GetKeyDown(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;
    
    // [Header("foo")] - creates a header in the unity menu
    [Header("Functional Options")]
    // [SerializeFeild] - lets the editor acess private values
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool canCrouch = true;
    [SerializeField] private bool canUseHeadbob = true;

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode crouchKey = KeyCode.C;

    [Header("Movement Parameters")]
    private float speed;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float sprintSpeed = 6f; 
    [SerializeField] private float crouchSpeed = 1.5f; 
    
    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80f;

    [Header("Jumping Parameters")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravity = 30f;

    [Header("Crouch Parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0f, 0.5f, 0f);
    [SerializeField] private Vector3 standingCenter = new Vector3(0f, 0f, 0f);
    private bool isCrouching;
    private bool duringCrouchAnimation;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float sprintBobSpeed = 18f;
    [SerializeField] private float sprintBobAmount = 0.1f;
    [SerializeField] private float crouchBobSpeed = 8f;
    [SerializeField] private float crouchBobAmount = 0.025f;
    private float defaultYPos = 0;
    private float timer;
    private float minimumMovementToBob = 3f;

    // [NOTE] variables should always be private, public variables can be modified by anything at any time, causing bugs in the Unity game engine
    // [NOTE] variables that need to be publically available use getter setter method as seen above
    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    private void Awake() {
        // get the camera attacked to the object
        playerCamera = GetComponentInChildren<Camera>();
        // get the character controller componant attached to the object
        characterController = GetComponentInChildren<CharacterController>();
        // set the default Y position of the camera for headbob
        defaultYPos = playerCamera.transform.localPosition.y;
        // lock the cursor to the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        // if the player is allowed to move, handle user input > handle mouse input > handle jumping > output
        if (CanMove) {
            HandleMovementInput();
            HandleMouseLook();
            if(canJump)
                HandleJump();

            if (canCrouch)
                HandleCrouch();

            if (canUseHeadbob)
                HandleHeadbob();

            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput() {
        // create a 2d array for x and z movement
        // (bool ? foo1 : foo2) - checks the bool, if true uses first option, if false uses second option
        speed = isCrouching ? crouchSpeed : IsSprinting ? sprintSpeed : walkSpeed;
        currentInput = new Vector2(speed * Input.GetAxis("Vertical"), speed * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        // setup a vector3 for 2d movement
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        // handle vertical movement seperatly
        moveDirection.y = moveDirectionY; 
    }

    private void HandleMouseLook() {
        // [NOTE] rotations and translations work diffrent
        // [NOTE] rotating around the Y is the same as spinning the camera around a vertical pole
        // [NOTE] to make the camera ROTATE up if the mouse TRANSLATES up the X and Y must be swapped
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        // clamp the camera so you cannot rotate forever up/down
        // [NOTE] negative rotations rotate upward
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        // rotate the camera to look up and down
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // rotate the player to turn left and right
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);

    }

    private void HandleJump () {
        if (ShouldJump)
            moveDirection.y = jumpForce;
    }

    private void HandleCrouch() {
        if(ShouldCrouch)
            StartCoroutine(CrouchStand());
    }

    private void HandleHeadbob() {
        if(!characterController.isGrounded) return;

        if (Mathf.Abs(new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude) > minimumMovementToBob || (Mathf.Abs(defaultYPos - playerCamera.transform.localPosition.y) > 0.005f)) {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : IsSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : IsSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z
            );
        } else if (playerCamera.transform.localPosition.y != defaultYPos) {
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos,
                playerCamera.transform.localPosition.z
            );
        }

/*
        if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f) {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : IsSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : IsSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z
            );
        }
        */
    }

    private void ApplyFinalMovements() {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    // [NOTE] code here can be used for switching between two vales over time
    private IEnumerator CrouchStand() {
        // simple check to see if anything is above when attempting to stand
        if (isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up, 1f)) {
            yield break;
        }

        // set during varible to true
        duringCrouchAnimation = true;

        float timeElapsed = 0;
        // end value
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        // current value
        float currentHeight = characterController.height;
        // end value
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        // current value
        Vector3 currentCenter = characterController.center;

        // while (time < animationLength)
        // foo = Mathf.Lerp(current, target, time/animationLength)
        // [NOTE] Mathf.Lerp(start, end, time) - Linearly interpolates between the start and end for time
        while(timeElapsed < timeToCrouch) {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // [NOTE] due to slight diffrences in time ending values may not be exact
        // [NOTE] a work around is to set them directly to their exact values after the process
        characterController.height = targetHeight;
        characterController.center = targetCenter;

        // toggle foo to opposite
        isCrouching = !isCrouching;

        // duration has finished, switch during variable to false
        duringCrouchAnimation = false;
    }

    
}