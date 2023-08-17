using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    public LootBag lootBag;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (lootBag != null)
        {
            GameObject droppedItem = lootBag.GetDroppedItem();

            if (droppedItem != null)
            {
                lootBag.InstantiateLoot(droppedItem, transform.position);
            }
            
        }
        Destroy(gameObject);
    }

}
