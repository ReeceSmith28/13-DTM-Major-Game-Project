using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration; // The duration of invincibility after taking damage.

    private InvincibilityController invincibilityController; // Reference to the InvincibilityController script.

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>(); // Get the InvincibilityController component on this GameObject.
    }

    // Function to start player invincibility.
    public void StartInvincibilty()
    {
        invincibilityController.StartInvincibility(invincibilityDuration); // Call the StartInvincibility function in the InvincibilityController.
    }
}