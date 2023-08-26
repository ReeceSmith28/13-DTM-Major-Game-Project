using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyProjectile;

    [SerializeField]
    private float timeBetweenShots;

    [SerializeField]
    private float lastFireTime;

    private Transform GunOffset;

    private GameObject player;

    private Vector2 directionToPlayer;

    [SerializeField]
    private float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastFireTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime;
        if (lastFireTime <= 0)
        {
            Shoot();
            lastFireTime = timeBetweenShots;

        }
    }

    void Shoot()
    {
        Instantiate(enemyProjectile, transform.position, Quaternion.identity);
    }
}
