using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth; // The current health of the object.

    [SerializeField]
    private float maximumHealth; // The maximum health this object can have.

    public bool isInvincible { get; set; } // A flag indicating if the object is currently invincible.

    // A property to get the remaining health percentage.
    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    // UnityEvents for various health-related events.
    public UnityEvent OnDied; // Event triggered when the object's health reaches zero.
    public UnityEvent OnDamaged; // Event triggered when the object takes damage.
    public UnityEvent OnHealthChanged; // Event triggered whenever the health changes.

    // Function to apply damage to the object's health.
    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return; // If health is already zero, no further damage can be taken.
        }

        if (isInvincible)
        {
            return; // If the object is invincible, no damage is taken.
        }

        currentHealth -= damageAmount; // Reduce the current health by the specified damage amount.

        OnHealthChanged.Invoke(); // Trigger the health changed event.

        if (currentHealth < 0)
            currentHealth = 0; // Ensure health doesn't go below zero.

        if (currentHealth == 0)
        {
            OnDied.Invoke(); // Trigger the "died" event when health reaches zero.
            SceneManager.LoadScene(2); // Load a specific scene (you might want to customize this).
            Cursor.visible = true; // Show the cursor.
        }
        else
        {
            OnDamaged.Invoke(); // Trigger the "damaged" event when health is reduced but not zero.
        }
    }

    // Function to add health to the object.
    public void AddHealth(float amounttoAdd)
    {
        if (currentHealth == maximumHealth)
        {
            return; // If current health is already at maximum, no more health can be added.
        }

        currentHealth += amounttoAdd; // Add the specified amount to current health.

        OnHealthChanged.Invoke(); // Trigger the health changed event.

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth; // Ensure health doesn't exceed the maximum.
        }
    }

    // Function to increase the maximum health of the object.
    public void IncreaseMaxHealth(float addAmount)
    {
        maximumHealth += addAmount;
    }
}