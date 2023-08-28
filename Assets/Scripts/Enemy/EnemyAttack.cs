using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmount; // The amount of damage this enemy's attack inflicts.

    [SerializeField]
    private float timeBetweenAttacks; // The time interval between consecutive attacks.

    private float lastTimeDamage; // The time since the last attack.

    // OnCollisionStay2D is called when this object continuously collides with another collider.
    private void OnCollisionStay2D(Collision2D collision)
    {
        lastTimeDamage -= Time.deltaTime; // Reduce the time since the last attack with each frame.

        // Check if the collision involves an object with a "PlayerMovement" component and enough time has passed between attacks.
        if (collision.gameObject.GetComponent<PlayerMovement>() && lastTimeDamage <= 0)
        {
            var HealthController = collision.gameObject.GetComponent<HealthController>(); // Get the player's HealthController.

            HealthController.TakeDamage(damageAmount); // Inflict damage to the player's health.

            lastTimeDamage = timeBetweenAttacks; // Reset the time until the next attack can occur.
        }
    }
}