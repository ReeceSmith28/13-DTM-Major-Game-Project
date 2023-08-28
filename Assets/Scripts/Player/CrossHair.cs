using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // Hide the cursor when the game starts.
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in the world coordinates.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the Z position of the crosshair to match the camera's near clip plane for proper depth rendering.
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

        // Update the position of the crosshair to follow the mouse.
        transform.position = mousePosition;
    }
}