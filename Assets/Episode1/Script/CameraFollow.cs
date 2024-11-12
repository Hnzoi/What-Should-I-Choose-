using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float followSpeed = 2f; // Camera follow speed
    public Vector3 offset = new Vector3(2f, 1f, -10f); // Offset in front of the player
    public float smoothTime = 0.3f; // Smoothing time for camera movement

    private Vector3 velocity = Vector3.zero; // Velocity for smooth damp

    // Define camera boundaries
    public float minX = -13.8f; // Minimum X position
    public float maxX = 2.7f; // Maximum X position

    void LateUpdate()
    {
        // Check player's direction by looking at localScale x value
        float direction = player.localScale.x > 0 ? 1 : -1;

        // Adjust the offset based on the direction the player is facing
        Vector3 targetPosition = player.position + new Vector3(offset.x * direction, offset.y, offset.z);

        // Clamp the camera's X position within the defined boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
