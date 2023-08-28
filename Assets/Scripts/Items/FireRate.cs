using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd; // The amount to increase the player's fire rate by when collected.

    // OnTriggerEnter2D is called when this object's collider triggers with another collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision involves an object with a "PlayerMovement" component.
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var PlayerShoot = other.gameObject.GetComponent<PlayerShoot>(); // Get the player's PlayerShoot component.

            PlayerShoot.FireRateIncrease(amounttoAdd); // Increase the player's fire rate.

            Destroy(gameObject); // Destroy this pickup object after it's collected by the player.
        }
    }
}