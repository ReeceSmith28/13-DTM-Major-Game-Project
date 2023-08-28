using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareOfPlayerController : MonoBehaviour
{
    public bool Awareofplayer { get; private set; } // A boolean flag indicating if the enemy is aware of the player's presence.

    public Vector2 Directiontoplayer { get; private set; } // The direction vector from the enemy to the player.

    [SerializeField]
    private float Playerawarenessdistnce; // The distance at which the enemy becomes aware of the player.

    private Transform player; // The transform (position) of the player.

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Find the player's transform in the scene.
    }

    // FixedUpdate is called at a fixed time interval and is used for physics-related updates.
    void FixedUpdate()
    {
        Vector2 enemytoPlayerVector = player.position - transform.position; // Calculate the vector from the enemy to the player.
        Directiontoplayer = enemytoPlayerVector.normalized; // Normalize the vector to get the direction.

        // Check if the distance between the enemy and the player is less than or equal to the awareness distance.
        if (enemytoPlayerVector.magnitude <= Playerawarenessdistnce)
        {
            Awareofplayer = true; // Set the awareness flag to true if the player is within the awareness distance.
        }
        else
        {
            Awareofplayer = false; // Set the awareness flag to false if the player is outside the awareness distance.
        }
    }
}