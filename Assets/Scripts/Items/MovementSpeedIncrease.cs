using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedIncrease : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd; // The amount to increase the player's movement speed by.

    // OnTriggerEnter2D is called when this object's collider triggers with another collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision involves an object with a "PlayerMovement" component.
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var PlayerShoot = other.gameObject.GetComponent<PlayerMovement>(); // Get the player's PlayerMovement component.

            PlayerShoot.MoveIncrease(amounttoAdd); // Increase the player's movement speed.

            Destroy(gameObject); // Destroy this pickup object after it's collected by the player.
        }
    }
}