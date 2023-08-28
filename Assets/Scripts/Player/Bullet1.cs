using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage; // The amount of damage this bullet inflicts on its target.

    private void Start()
    {
        // This Start function is empty, with no specific initialization code.
    }

    // OnTriggerEnter2D is called when this object's collider triggers with another collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision involves an object with an "EnemyMovement" component.
        if (collision.GetComponent<EnemyMovement>())
        {
            // Get the "EnemyHealth" component of the collided enemy and apply damage to it.
            var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            EnemyHealth.TakeDamage(bulletDamage);

            // Destroy this bullet object upon collision.
            Destroy(gameObject);
        }

        // Check if the collision involves an object with a "projectileEnemyMovement" component.
        if (collision.GetComponent<projectileEnemyMovement>())
        {
            // Get the "EnemyHealth" component of the collided enemy and apply damage to it.
            var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            EnemyHealth.TakeDamage(bulletDamage);

            // Destroy this bullet object upon collision.
            Destroy(gameObject);
        }

        // Check if the collision involves an object with a "Boss" component.
        if (collision.GetComponent<Boss>())
        {
            // Get the "Boss" component of the collided boss enemy and apply damage to it.
            var Boss = collision.gameObject.GetComponent<Boss>();
            Boss.TakeDamage(bulletDamage);

            // Destroy this bullet object upon collision.
            Destroy(gameObject);
        }

        // Check if the collision involves an object with the tag "Obstacle".
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destroy this bullet object upon collision with an obstacle.
            Destroy(gameObject);
        }
    }
}