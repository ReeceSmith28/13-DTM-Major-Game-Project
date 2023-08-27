using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int Health;
    private Rigidbody2D rigidBody;
    private Vector2 distanceToPlayer;
    private Vector2 directionToPlayer;
    private Transform player;
    public int stoppingDistance;
    public GameObject bossProjectile;
    public int projectileSpeed;
    private int lastFireTime;
    public int timeBetweenShots;

    [SerializeField]
    private int speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidBody = GetComponent<Rigidbody2D>();
        lastFireTime = timeBetweenShots;
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
            Shoot();
        }
        else
        {
            rigidBody.velocity = speed * directionToPlayer;
        }
        
        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bossProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = projectileSpeed * directionToPlayer;
    }
}
