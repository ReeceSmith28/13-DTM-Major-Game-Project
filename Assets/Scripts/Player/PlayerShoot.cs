using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // The prefab of the bullet the player will shoot.

    [SerializeField]
    private float bulletSpeed; // The speed at which the bullets will travel.

    [SerializeField]
    private float timeBetweenShots; // The time delay between consecutive shots.

    private bool fireContinue; // A flag to indicate if the player continues to fire (not used in this code).
    private float lastFireTime; // The time when the player last fired a shot.

    private Transform pointerTransform; // The transform of the aiming pointer.

    private Transform GunOffset; // The transform for the gun's position offset.

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime; // Decrease the time since the last shot with each frame.

        // Check if the left mouse button is pressed and enough time has passed since the last shot.
        if (Input.GetMouseButton(0) && lastFireTime <= 0)
        {
            fireBullet(); // Call the function to fire a bullet.
            lastFireTime = timeBetweenShots; // Reset the time until the next shot.
        }
    }

    private void fireBullet()
    {
        GunOffset = GameObject.FindGameObjectWithTag("GunOffset").GetComponent<Transform>(); // Find the gun offset position.
        pointerTransform = FindObjectOfType<Pointer>().GetComponent<Transform>(); // Find the aiming pointer's transform.

        // Create an instance of the bullet prefab at the gun's offset position with the same rotation as the gun.
        GameObject bullet = Instantiate(bulletPrefab, GunOffset.position, GunOffset.rotation);

        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bullet.

        // Set the bullet's velocity to make it move in the direction pointed by the aiming pointer.
        rigidbody2D.velocity = bulletSpeed * pointerTransform.right;
    }

    // Function to increase the player's fire rate by reducing the time between shots.
    public void FireRateIncrease(float fireRateAdd)
    {
        timeBetweenShots -= fireRateAdd; // Reduce the time between shots.
    }
}