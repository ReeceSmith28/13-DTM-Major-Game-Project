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
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);


    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);



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
