using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth; // The maximum health of the enemy.

    private int currentHealth; // The current health of the enemy.

    public LootBag lootBag; // A reference to a LootBag script that handles dropping items upon enemy death.

    private void Start()
    {
        currentHealth = maxHealth; // Initialize the current health to the maximum health when the enemy is created.
    }

    // Function to reduce the enemy's health when it takes damage.
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce the current health by the specified damage amount.
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function when the enemy's health reaches or falls below zero.
        }
    }

    // Function to handle the enemy's death.
    public void Die()
    {
        if (lootBag != null)
        {
            GameObject droppedItem = lootBag.GetDroppedItem(); // Get a reference to a dropped item (if any) from the loot bag.

            if (droppedItem != null)
            {
                lootBag.InstantiateLoot(droppedItem, transform.position); // Instantiate the dropped item at the enemy's position.
            }
        }

        Destroy(gameObject); // Destroy the enemy object when it dies.
    }
}