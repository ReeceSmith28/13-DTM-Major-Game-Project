using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 distanceToPlayer;
    private Vector2 directionToPlayer;
    private Transform player;
    public int stoppingDistance;
    public GameObject enemyProjectile;
    public int projectileSpeed;
    private float lastFireTime;
    public float timeBetweenShots;

    [SerializeField]
    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime;
        distanceToPlayer = player.position - transform.position;
        directionToPlayer = distanceToPlayer.normalized;
        if (distanceToPlayer.magnitude <= stoppingDistance)
        {
            rigidBody.velocity = Vector2.zero;
            if (lastFireTime <= 0)
            {
                Shoot();
                lastFireTime = timeBetweenShots;
            }

        }
        else
        {
            rigidBody.velocity = speed * directionToPlayer;
        }


    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = projectileSpeed * directionToPlayer;
    }
}
