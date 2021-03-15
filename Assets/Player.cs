using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerCamera;
    public CharacterController characterController;
    public float speed;
    public bool isDoubleJumpAvailable;
    public Vector3 moveVector;
    public float gravitySpeed;
    public float lastGrounded;

    private void Update()
    {
        HandleGrounded();
        HandleMovement();
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
            gravitySpeed -= 10 * Time.deltaTime;
        }
    }
    void HandleMovement()
    {
        moveVector = new Vector3(1 * Input.GetAxisRaw("Horizontal"), 0, 0);
        moveVector.y = 0;
        moveVector *= speed;
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
}
