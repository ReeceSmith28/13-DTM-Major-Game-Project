using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    [SerializeField]
    private float amounttoAdd;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            var HealthController = collision.gameObject.GetComponent<HealthController>();

            HealthController.AddHealth(amounttoAdd);

            Destroy(gameObject);
        }
    }
}
