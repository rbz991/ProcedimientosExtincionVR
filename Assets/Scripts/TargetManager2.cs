using UnityEngine;

public class TargetManager2 : MonoBehaviour
{
    public GameObject targetPrefab; // The prefab for the target to spawn
    public Transform[] spawnPoints; // Array of spawn points
    private GameObject currentTarget; // Currently active target
    private int lastSpawnIndex = -1; // To store the last used spawn index
    public float moveDistance = 5f; // Distance each target will move
    public float moveSpeed = 1f; // Speed of the movement
    public Vector3 moveDirection = Vector3.forward; // Direction of the movement

    void Update()
    {
        // Check if there is no current target
        if (currentTarget == null)
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        int spawnIndex = -1;

        // Keep picking a random index until it is different from the last used index
        do
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
        } while (spawnIndex == lastSpawnIndex && spawnPoints.Length > 1); // Check to prevent infinite loop when there's only one spawn point

        // Instantiate the target at the chosen spawn point
        currentTarget = Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

        // Attach and configure the MoveAfterSpawn script
        MoveAfterSpawn mover = currentTarget.AddComponent<MoveAfterSpawn>();
        mover.movementDirection = moveDirection;
        mover.distance = moveDistance;
        mover.speed = moveSpeed;

        // Update lastSpawnIndex to the new index
        lastSpawnIndex = spawnIndex;
    }
}
