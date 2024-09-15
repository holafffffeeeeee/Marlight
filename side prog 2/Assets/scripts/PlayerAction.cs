
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Make sure to include this for the new Input System

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;  // Speed of the player

    private PlayerInputActions playerInputActions;  // Reference to the auto-generated input actions
    private Vector2 movement;  // Stores the movement input
    private Rigidbody2D rb;    // Reference to the Rigidbody2D component

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        playerInputActions = new PlayerInputActions();  // Instantiate the PlayerInputActions class
    }

    private void OnEnable()
    {
        playerInputActions.Enable();  // Enable the input actions

        // Register the movement action
        playerInputActions.Player.Movement.performed += OnMove;   // Called when movement starts or changes
        playerInputActions.Player.Movement.canceled += OnMove;    // Called when movement stops
    }

    private void OnDisable()
    {
        // Unregister the movement action
        playerInputActions.Player.Movement.performed -= OnMove;
        playerInputActions.Player.Movement.canceled -= OnMove;

        playerInputActions.Disable();  // Disable the input actions
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Read the movement input
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Move the player based on input
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
