using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maximumHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
            return;


        currentHealth -= damageAmount;

        if (currentHealth < 0)
            currentHealth = 0;

    }

    public void AddHealth(float amounttoAdd)
    {
        if (currentHealth == maximumHealth)
        {
            return;
        }

        currentHealth += amounttoAdd;

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }

}
