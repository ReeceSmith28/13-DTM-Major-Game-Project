using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed;

    private AwareOfPlayerController playerAwarenessController;
    private Vector2 targetDirection;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<AwareOfPlayerController>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        Debug.Log("Direction to player: " + targetDirection);
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (playerAwarenessController.Awareofplayer)
        {
            targetDirection = playerAwarenessController.Directiontoplayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void SetVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            rigidbody2D.velocity = targetDirection * speed;
        }
    }
}
