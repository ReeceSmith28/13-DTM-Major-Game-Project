using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int Health; // Set an integer that acts as the boss's health.
    private Rigidbody2D rigidBody; // A variable used to store the rigidbody information.
    private Vector2 distanceToPlayer; // Distance from the boss to the player.
    private Vector2 directionToPlayer; // The direction of the player in relation to the boss.
    private Transform player; // The transform of the player (position).
    public int stoppingDistance; // The distance from the player at which the boss needs to stop moving and start shooting.
    public GameObject bossProjectile; // The prefab of the projectile used by the boss.
    public int projectileSpeed; // Speed at which the projectile moves.
    private float lastFireTime; // The last time a bullet was fired.
    public float timeBetweenShots; // The time between each projectile shot.

    [SerializeField]
    private int speed; // The speed at which the enemy will move toward the player.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the transform of the object with the tag "player".
        rigidBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime; // Reduce the last time a bullet was shot by one every frame.
        distanceToPlayer = player.position - transform.position; // Get the distance to the player.
        directionToPlayer = distanceToPlayer.normalized; // Get the direction of the player in relation to the boss.

        // If the distance from the player is smaller than the stopping distance, stop moving and start shooting.
        // Otherwise, keep moving toward the player.
        if (distanceToPlayer.magnitude <= stoppingDistance)
        {
            rigidBody.velocity = Vector2.zero; // Stop the boss's movement.
            if (lastFireTime <= 0)
            {
                Shoot(); // Call the Shoot function to fire a projectile.
                lastFireTime = timeBetweenShots; // Reset the time until the next shot.
            }
        }
        else
        {
            rigidBody.velocity = speed * directionToPlayer; // Move the boss toward the player.
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bossProjectile, transform.position, Quaternion.identity);
        // Create a projectile instance at the boss's position with no rotation.
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = projectileSpeed * directionToPlayer; // Set the projectile's velocity.
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount; // Reduce the boss's health by the given damage amount.
        if (Health <= 0)
        {
            Die(); // Call the Die function when the boss's health reaches or falls below zero.
        }
    }

    public void Die()
    {
        Destroy(gameObject); // Destroy the boss object.
        SceneManager.LoadScene(3); // Load win scene.
        Cursor.visible = true; // Show the cursor.
    }
}