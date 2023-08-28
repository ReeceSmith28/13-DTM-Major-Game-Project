using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage; // The amount of damage this projectile inflicts on the player.

    private void Start()
    {
        // This Start function is empty, with no specific initialization code.
    }

    // OnTriggerEnter2D is called when this object's collider triggers with another collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision involves an object with a "PlayerMovement" component.
        if (collision.GetComponent<PlayerMovement>())
        {
            var health = collision.gameObject.GetComponent<HealthController>(); // Get the player's HealthController.

            health.TakeDamage(bulletDamage); // Inflict damage to the player's health.

            Destroy(gameObject); // Destroy this projectile object upon collision with the player.
        }

        // Check if the collision involves an object with the tag "Obstacle".
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Destroy this projectile object upon collision with an obstacle.
        }
    }
}