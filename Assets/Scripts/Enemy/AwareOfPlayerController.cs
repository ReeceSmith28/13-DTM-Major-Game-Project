using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareOfPlayerController : MonoBehaviour
{

    public bool Awareofplayer { get; private set; }

    public Vector2 Directiontoplayer { get; private set; }

    [SerializeField]

    private float Playerawarenessdistnce;

    private Transform player;
        private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 enemytoPlayerVector = player.position - transform.position;
        Directiontoplayer = enemytoPlayerVector.normalized;

            if (enemytoPlayerVector.magnitude <= Playerawarenessdistnce)
            {
            Awareofplayer = true;        

            }
            else
            {
            Awareofplayer = false;
            }
        
     }
}
