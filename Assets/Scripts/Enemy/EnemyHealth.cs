using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    public LootBag lootBag;

    public GameObject waveCounter;

    private void Start()
    {
        currentHealth = maxHealth;
        //int waveEnd = waveCounter.remainingEnemies;
    }

    public void Update()
    {
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

        //var wavecounter = gameObject.GetComponent<WaveCounter>();
        //wavecounter.WaveDecrease(1);

        Destroy(gameObject);
    }

}
