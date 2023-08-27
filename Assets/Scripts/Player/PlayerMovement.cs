using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;
    private Vector2  movementInput;
    public float speed;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    public float movesmooth;
    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,
            movesmooth);
        GetComponent<Rigidbody2D>().velocity = smoothedMovementInput * speed;
        SetAnimation();  
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

    }

    public void MoveIncrease(float moveAdd)
    {
        speed += moveAdd;
    }

    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        
    }
}
