using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign this in the inspector
    public Transform bulletSpawnPoint; // Assign or set to this object's transform

   
    void ShootBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Bullet prefab or spawn point not assigned!");
        }
    }
}
