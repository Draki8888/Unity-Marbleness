using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingINputSystem : MonoBehaviour
{
    private Rigidbody sphereRigidbody;
    private PlayerInputActions playerInputActions;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float moveSpeed = 5f;

    //test

    private void Awake()
    {
        //grabbing components
        sphereRigidbody = GetComponent<Rigidbody>();

        //getting the input action class,enabling the player, and subscribing to the move and jump actions
         playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
       
    }

    private void FixedUpdate()
    {
        Move_Ball();
    }

    //moving the ball
    private void Move_Ball()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed, ForceMode.Force);
    }

    // context for + making the Jump
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump!" + context.phase);
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


}

