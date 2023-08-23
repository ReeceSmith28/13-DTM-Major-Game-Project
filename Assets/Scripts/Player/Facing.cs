using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Transform crosshairPos; 
    public Transform player;
    public bool facingLeft;
    public bool facingRight;

    private void Start()
    {
        crosshairPos = FindObjectOfType<CrossHair>().transform;
        player = FindObjectOfType<PlayerMovement>().transform;

    }
}

    
