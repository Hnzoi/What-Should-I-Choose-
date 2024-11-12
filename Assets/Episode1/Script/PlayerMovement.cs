using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float minX = -21f;
    public float maxX = 10f;

    public Transform targetObject;
    public float minScale = 1f;
    public float maxScale = 1.3f;
    public float distanceThreshold = 7f;

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale; // Store the initial scale of the player
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Check for left arrow or "A" key press
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            movement = Vector3.left;
            transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // Flip to left
        }
        // Check for right arrow or "D" key press
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            movement = Vector3.right;
            transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // Flip to right
        }

        // Calculate new position based on movement
        Vector3 newPosition = transform.position + (movement * playerSpeed * Time.deltaTime);

        // Clamp position to boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;

        // Adjust scale based on distance to the target object
        float distance = Vector3.Distance(transform.position, targetObject.position);
        float scale = Mathf.Lerp(maxScale, minScale, distance / distanceThreshold);
        transform.localScale = new Vector3(transform.localScale.x, initialScale.y * scale, initialScale.z);
    }
}
