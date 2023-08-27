using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage;

    public Transform player;

    public float speed;

    private Vector2 target;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position - transform.position;

        // Get a reference to the Rigidbody2D component
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component is missing
        if (rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the enemyProjectile.");
            // You can add further error handling here.
        }
    }

    private void Update()
    {
        if (rigidbody2D != null) // Check if rigidbody2D is not null before accessing it
        {
            rigidbody2D.velocity = speed * target;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            var playerHealth = collision.gameObject.GetComponent<HealthController>();
            playerHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}