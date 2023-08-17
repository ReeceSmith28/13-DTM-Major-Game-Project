using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            var HealthController = other.gameObject.GetComponent<HealthController>();

            HealthController.AddHealth(amounttoAdd);

            Destroy(gameObject);
        }
    }
}
