using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform centerPoint;  // The center point around which to orbit
    public float orbitRadius = 5.0f;  // Orbit radius
    public float orbitSpeed = 1.0f;  // Speed of the orbit
    public Vector3 rotationAxis = Vector3.up; // Axis to rotate around
    public float rotationSpeed = 50f; // Speed of rotation
    private float orbitAngle = 0f;  // Current angle of the orbit

    void Update()
    {
        if (centerPoint == null) return;  // Safety check

        // Increment the angle based on speed and time
        orbitAngle += orbitSpeed * Time.deltaTime;
        orbitAngle %= 360f;  // Keep the angle in the range of 0-360 degrees

        // Calculate the new position using trigonometry
        float x = centerPoint.position.x + orbitRadius * Mathf.Cos(orbitAngle * Mathf.Deg2Rad);
        float z = centerPoint.position.z + orbitRadius * Mathf.Sin(orbitAngle * Mathf.Deg2Rad);

        // Set the position keeping the same y as the centerPoint or the original y
        transform.position = new Vector3(x, transform.position.y, z);
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
