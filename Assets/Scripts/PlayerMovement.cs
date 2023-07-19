using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private Vector2  _movementInput;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponents<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = _movementInput;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();

    }
}
