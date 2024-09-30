using UnityEngine;
using System.Collections;

public class ObjectBobbing : MonoBehaviour
{
    public float bobbingAmount = 0.5f; // How high the object bobs
    public float bobbingSpeed = 2f; // How fast the object bobs
    public Vector3 rotationAxis = Vector3.up; // Axis to rotate around
    public float rotationSpeed = 50f; // Speed of rotation
    public float collisionBoostDuration = 2f; // How long the speed boost lasts after collision
    public float collisionBoostMultiplier = 2f; // How much to multiply the bobbing speed by after collision

    private float originalY; // Original y-position of the object, updated dynamically
    private float currentBobbingSpeed; // Current bobbing speed
    private Vector3 lastPosition; // To check if the object has moved
    private bool isMoving; // Flag to check if the object is moving

    void Start()
    {
        currentBobbingSpeed = bobbingSpeed; // Initialize with the normal bobbing speed
        lastPosition = transform.position; // Initialize last position
        originalY = transform.position.y; // Set initial originalY
    }

    void Update()
    {
        // Check if the object has moved
        bool wasMoving = isMoving;
        isMoving = Vector3.Distance(transform.position, lastPosition) > 0.001f; // Adjust the threshold as needed
        lastPosition = transform.position; // Update last position for the next frame

        // Update the starting position for bobbing when the object stops moving
        if (wasMoving && !isMoving)
        {
            originalY = transform.position.y;
        }

        // Bobbing Motion
        if (!isMoving) // Only bob if the object is not moving
        {
            float newY = originalY + Mathf.Sin(Time.time * currentBobbingSpeed) * bobbingAmount;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        // Rotation
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Start the speed boost coroutine when a collision occurs
        //if (Utilidades.currentPhase == 1 || Utilidades.currentPhase == 2)
        //{ 
        //StartCoroutine(BobbingSpeedBoost());
        //} 

        
    }

    IEnumerator BobbingSpeedBoost()
    {
        // Increase the bobbing speed temporarily
        float originalSpeed = currentBobbingSpeed;
        currentBobbingSpeed *= collisionBoostMultiplier;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(collisionBoostDuration);

        // Reset the bobbing speed to normal
        currentBobbingSpeed = originalSpeed;
    }
}
