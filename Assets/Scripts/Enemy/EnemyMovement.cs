using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D; // Reference to the Rigidbody2D component for movement.

    [SerializeField]
    private float speed; // The speed at which the enemy moves.

    private AwareOfPlayerController playerAwarenessController; // Reference to the AwareOfPlayerController for player awareness.

    private Vector2 targetDirection; // The direction in which the enemy should move.

    // Awake is called when the object is initialized.
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component on this GameObject for movement.
        playerAwarenessController = GetComponent<AwareOfPlayerController>(); // Get the AwareOfPlayerController for player awareness.
    }

    // FixedUpdate is called at a fixed time interval and is used for physics-related updates.
    private void FixedUpdate()
    {
        UpdateTargetDirection(); // Update the target direction based on player awareness.
        Debug.Log("Direction to player: " + targetDirection); // Log the direction to the player.
        SetVelocity(); // Set the velocity of the enemy based on the target direction and speed.
    }

    // Function to update the target direction based on player awareness.
    private void UpdateTargetDirection()
    {
        if (playerAwarenessController.Awareofplayer)
        {
            targetDirection = playerAwarenessController.Directiontoplayer; // Set the target direction to the direction to the player.
        }
        else
        {
            targetDirection = Vector2.zero; // If not aware of the player, set the target direction to zero (no movement).
        }
    }

    // Function to set the velocity of the enemy based on the target direction and speed.
    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rigidbody2D.velocity = Vector2.zero; // If the target direction is zero, stop the enemy's movement.
        }
        else
        {
            rigidbody2D.velocity = targetDirection * speed; // Set the velocity to move in the target direction at the specified speed.
        }
    }
}