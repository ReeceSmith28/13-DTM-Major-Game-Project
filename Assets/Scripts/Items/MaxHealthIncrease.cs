using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthIncrease : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var PlayerShoot = other.gameObject.GetComponent<HealthController>();

            PlayerShoot.IncreaseMaxHealth(amounttoAdd);

            Destroy(gameObject);
        }
    }
}
