using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    [SerializeField]
    private float timeBetweenAttacks;
    
    private float lastTimeDamage;


    private void OnCollisionStay2D(Collision2D collision)
    {
        lastTimeDamage -= Time.deltaTime;
        if (collision.gameObject.GetComponent<PlayerMovement>()&& lastTimeDamage <= 0)
        {
            var HealthController = collision.gameObject.GetComponent<HealthController>();

            HealthController.TakeDamage(damageAmount);

            lastTimeDamage = timeBetweenAttacks;
        }
    }
}
