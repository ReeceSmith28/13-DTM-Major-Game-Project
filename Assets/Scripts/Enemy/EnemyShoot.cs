using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyProjectile; // The projectile to be fired by the enemy.

    [SerializeField]
    private float timeBetweenShots; // The time interval between each shot.

    private float lastFireTime; // The time of the last shot.

    private GameObject player; // Reference to the player GameObject.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find and store the player GameObject.
        lastFireTime = 0f; // Initialize the lastFireTime to zero.
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime; // Decrease the time since the last shot.

        // If enough time has passed, it's time to shoot again.
        if (lastFireTime <= 0)
        {
            Shoot(); // Fire a projectile.
            lastFireTime = timeBetweenShots; // Reset the time for the next shot.
        }
    }

    // Shoot method instantiates a projectile.
    void Shoot()
    {
        Instantiate(enemyProjectile, transform.position, Quaternion.identity); // Create a new enemy projectile at the enemy's position.
    }
}