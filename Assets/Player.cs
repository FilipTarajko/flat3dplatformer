using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerCamera;
    public Transform cameraParent;
    public CharacterController characterController;
    public float speed;
    public bool isDoubleJumpAvailable;
    public Vector3 moveVector;
    public float gravitySpeed;
    public float lastGrounded;
    public float turningFactor;
    public float cameraFollowTime;
    public float addedX;
    public Vector3 smoothDampSpeedPlayer = Vector3.zero;
    private Vector3 smoothDampSpeedCamera = Vector3.zero;

    private void Update()
    {
        HandleGrounded();
        HandleMovement();
        HandleCamera();
    }

    void HandleGrounded()
    {
        lastGrounded += Time.deltaTime;
        if (characterController.isGrounded)
        {
            isDoubleJumpAvailable = true;
            if (lastGrounded > 0.1f)
            {
                gravitySpeed = -0.2f;
            }
            lastGrounded = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gravitySpeed -= 10 * Time.deltaTime;
            }
            else
            {
                gravitySpeed -= 20 * Time.deltaTime;
            }
        }
    }
    void HandleMovement()
    {
        moveVector = Vector3.SmoothDamp(moveVector, new Vector3(speed * Input.GetAxisRaw("Horizontal"), 0, 0), ref smoothDampSpeedPlayer, turningFactor);
        moveVector.y = gravitySpeed;
        characterController.Move(moveVector * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && lastGrounded < 0.15)
        {
            gravitySpeed = 10;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isDoubleJumpAvailable)
        {
            gravitySpeed = 10;
            isDoubleJumpAvailable = false;
        }
    }

    void HandleCamera()
    {
        cameraParent.position = Vector3.SmoothDamp(cameraParent.position, transform.position, ref smoothDampSpeedCamera, cameraFollowTime); 
    }
}
