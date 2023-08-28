using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // The player's Rigidbody2D component for physics-based movement.
    private Vector2 movementInput; // Stores the player's input for movement.
    public float speed; // The speed at which the player moves.
    private Vector2 smoothedMovementInput; // Smoothed input for gradual movement changes.
    private Vector2 movementInputSmoothVelocity; // Velocity for smoothing the movement input.
    public float moveSmooth; // The smoothness factor for interpolating movement.
    private Animator animator; // The animator component for controlling player animations.

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>(); // Get the Animator component on the player object.
    }

    // FixedUpdate is called at a fixed time interval and is used for physics-related updates.
    private void FixedUpdate()
    {
        // Smooth the movement input for gradual changes in movement direction.
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,
            moveSmooth);

        // Set the player's velocity to move them based on the smoothed input.
        GetComponent<Rigidbody2D>().velocity = smoothedMovementInput * speed;

        // Call a function to set the appropriate animation state based on movement.
        SetAnimation();
    }

    // Callback function for the "Move" action in the Input System.
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>(); // Get the movement input from the input value.
    }

    // Function to increase the player's movement speed.
    public void MoveIncrease(float moveAdd)
    {
        speed += moveAdd; // Add the provided value to the player's speed.
    }

    // Function to set the player's animation based on their movement.
    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero; // Check if the player is moving (not idle).
        animator.SetBool("isMoving", isMoving); // Set the "isMoving" parameter in the animator.
    }
}