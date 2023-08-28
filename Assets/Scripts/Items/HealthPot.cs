using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd; // The amount to increase the player's health by when collected.

    // OnTriggerEnter2D is called when this object's collider triggers with another collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision involves an object with a "PlayerMovement" component.
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var HealthController = other.gameObject.GetComponent<HealthController>(); // Get the player's HealthController component.

            HealthController.AddHealth(amounttoAdd); // Increase the player's health.

            Destroy(gameObject); // Destroy this health potion object after it's collected by the player.
        }
    }
}