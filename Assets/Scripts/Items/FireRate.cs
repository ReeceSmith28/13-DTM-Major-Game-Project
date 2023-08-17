using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRate : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var PlayerShoot = other.gameObject.GetComponent<PlayerShoot>();

            PlayerShoot.FireRateIncrease(amounttoAdd);

            Destroy(gameObject);
        }
    }
}
