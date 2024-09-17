using UnityEngine;
using System.Collections;

public class MoveAfterSpawn : MonoBehaviour
{
    public Vector3 movementDirection = Vector3.forward; // Direction to move
    public float distance = 5f; // Distance to move
    public float speed = 1f; // Speed of movement

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        startPosition = transform.position; // Save the starting position
        targetPosition = startPosition + movementDirection.normalized * distance; // Calculate the target position

        StartCoroutine(MoveToPosition());
    }

    IEnumerator MoveToPosition()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
