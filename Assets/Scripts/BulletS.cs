using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float lifetime = 20f;

    void Start()
    {
       
        Destroy(gameObject, lifetime);
     
    }

   
}
