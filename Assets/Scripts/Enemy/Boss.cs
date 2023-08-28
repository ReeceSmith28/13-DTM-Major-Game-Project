using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject bullet = Instantiate(bossProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = projectileSpeed * directionToPlayer;
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(3);
        Cursor.visible = true;
    }
}
