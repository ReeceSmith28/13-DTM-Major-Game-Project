using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // This Start function is empty, with no specific initialization code.
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in the world coordinates.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction vector from this object to the mouse position.
        Vector2 direction = mousePosition - transform.position;

        // Calculate the angle in degrees between the direction vector and the right vector (Vector2.right).
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        // Set the rotation of this object to match the calculated angle.
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}