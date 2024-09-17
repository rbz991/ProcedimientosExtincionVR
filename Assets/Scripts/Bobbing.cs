using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float amplitude = 1f; // Amplitude of the bobbing, half the total height of the oscillation
    public float speed = 2f; // Speed of the bobbing

    private float originalY; // This will hold the initial y position of the GameObject
    private float lastY; // This will track the last y position to check for movement

    void Awake()
    {
        // Store the initial y position of the GameObject to calculate relative movement
        originalY = transform.position.y;
        lastY = originalY;
    }

    void Update()
    {
        // Check if the GameObject has moved significantly since last frame
        if (Mathf.Abs(lastY - transform.position.y) < 0.001f) // Adjust threshold as needed
        {
            // Calculate the new y position using a sine wave based on the current time and the speed
            float newY = originalY + Mathf.Sin(Time.time * speed) * amplitude;

            // Apply the new position to the GameObject
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        // Update the lastY to the current position for the next frame's comparison
        lastY = transform.position.y;
    }
}
