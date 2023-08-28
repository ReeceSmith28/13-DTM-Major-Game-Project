using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody; // The Rigidbody2D component for the enemy object.
    private Vector2 distanceToPlayer; // Distance from the enemy to the player.
    private Vector2 directionToPlayer; // The direction of the player in relation to the enemy.
    private Transform player; // The transform of the player (position).
    public int stoppingDistance; // The distance from the player at which the enemy needs to stop moving and start shooting.
    public GameObject enemyProjectile; // The prefab of the projectile used by the enemy.
    public int projectileSpeed; // Speed at which the projectile moves.
    private float lastFireTime; // The last time a bullet was fired.
    public float timeBetweenShots; // The time between each projectile shot.

    [SerializeField]
    private int speed; // The speed at which the enemy will move toward the player.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the transform of the object with the tag "Player".
        rigidBody = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the enemy.
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime; // Decrease the time since the last shot with each frame.
        distanceToPlayer = player.position - transform.position; // Get the distance to the player.
        directionToPlayer = distanceToPlayer.normalized; // Get the direction of the player in relation to the enemy.

        // If the distance from the player is smaller than the stopping distance, stop moving and start shooting.
        // Otherwise, keep moving toward the player.
        if (distanceToPlayer.magnitude <= stoppingDistance)
        {
            rigidBody.velocity = Vector2.zero; // Stop the enemy's movement.
            if (lastFireTime <= 0)
            {
                Shoot(); // Call the Shoot function to fire a projectile.
                lastFireTime = timeBetweenShots; // Reset the time until the next shot.
            }
        }
        else
        {
            rigidBody.velocity = speed * directionToPlayer; // Move the enemy toward the player.
        }
    }

    // Function to make the enemy shoot a projectile.
    public void Shoot()
    {
        GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        // Create an instance of the enemy's projectile at the enemy's position with no rotation.
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = projectileSpeed * directionToPlayer; // Set the projectile's velocity.
    }
}