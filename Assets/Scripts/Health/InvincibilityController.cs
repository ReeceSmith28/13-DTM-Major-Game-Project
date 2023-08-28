using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController; // Reference to the HealthController script.

    private void Awake()
    {
        healthController = GetComponent<HealthController>(); // Get the HealthController component on this GameObject.
    }

    // Function to start the invincibility duration.
    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration)); // Start the coroutine to handle invincibility.
    }

    // Coroutine that manages the invincibility duration.
    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        healthController.isInvincible = true; // Set the isInvincible flag in HealthController to true.

        // Wait for the specified invincibility duration.
        yield return new WaitForSeconds(invincibilityDuration);

        healthController.isInvincible = false; // Set the isInvincible flag back to false after invincibility ends.
    }
}