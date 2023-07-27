using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float timeBetweenShots;

    private bool fireContinue;
    private float lastFireTime;

    private Transform pointerTransform;

    private Transform GunOffset;



    // Update is called once per frame
    void Update()
    {
        lastFireTime -= Time.deltaTime;
        if (Input.GetMouseButton(0)&& lastFireTime <= 0)
        {
            fireBullet();
            lastFireTime = timeBetweenShots ;
        }

    }

    private void fireBullet()
    {
        GunOffset = GameObject.FindGameObjectWithTag("GunOffset").GetComponent<Transform>();
        pointerTransform = FindObjectOfType<Pointer>().GetComponent<Transform>();
        GameObject bullet = Instantiate(bulletPrefab, GunOffset.position, GunOffset.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = bulletSpeed * pointerTransform.right;
    }

    //private void OnFire(InputValue inputvalue)
    //{
    //    fireContinue = inputvalue.isPressed;
    
    
    //}
}
